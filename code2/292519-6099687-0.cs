        namespace U413.UI.CustomModelBinders
        {
            /// <summary>
            /// Override for DefaultModelBinder in order to implement fixes to its behavior.
            /// </summary>
            public class U413ModelBinder : DefaultModelBinder
            {
                /// <summary>
                /// Fix for the default model binder's failure to decode enum types when binding to JSON.
                /// </summary>
                protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext,
                    PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
                {
                    var propertyType = propertyDescriptor.PropertyType;
                    if (propertyType.IsEnum)
                    {
                        var providerValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                        if (null != providerValue)
                        {
                            var value = providerValue.RawValue;
                            if (null != value)
                            {
                                var valueType = value.GetType();
                                if (!valueType.IsEnum)
                                {
                                    return Enum.ToObject(propertyType, value);
                                }
                            }
                        }
                    }
                    return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
                }
            }
        }
