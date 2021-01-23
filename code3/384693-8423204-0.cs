    public class CommaSeparatedValuesModelBinder : DefaultModelBinder
    {
        private static readonly MethodInfo ToArrayMethod = typeof(Enumerable).GetMethod("ToArray");
     
        protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
        {
            if (propertyDescriptor.PropertyType.GetInterface(typeof(IEnumerable).Name) != null)
            {
                var actualValue = bindingContext.ValueProvider.GetValue(propertyDescriptor.Name);
     
                if (actualValue != null && !String.IsNullOrWhiteSpace(actualValue.AttemptedValue) && actualValue.AttemptedValue.Contains(","))
                {
                    var valueType = propertyDescriptor.PropertyType.GetElementType() ?? propertyDescriptor.PropertyType.GetGenericArguments().FirstOrDefault();
     
                    if (valueType != null && valueType.GetInterface(typeof(IConvertible).Name) != null)
                    {
                        var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(valueType));
     
                        foreach (var splitValue in actualValue.AttemptedValue.Split(new[] { ',' }))
                        {
                            list.Add(Convert.ChangeType(splitValue, valueType));
                        }
     
                        if (propertyDescriptor.PropertyType.IsArray)
                        {
                            return ToArrayMethod.MakeGenericMethod(valueType).Invoke(this, new[] { list });
                        }
                        else
                        {
                            return list;
                        }
                    }
                }
            }
     
            return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
        }
    }
