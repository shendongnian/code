    public class EnhancedModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            Type type = modelType;
            if (modelType.IsGenericType)
            {
                Type genericTypeDefinition = modelType.GetGenericTypeDefinition();
                if (genericTypeDefinition == typeof(IDictionary<,>))
                {
                    type = typeof(Dictionary<,>).MakeGenericType(modelType.GetGenericArguments());
                }
                else if (((genericTypeDefinition == typeof(IEnumerable<>)) || (genericTypeDefinition == typeof(ICollection<>))) || (genericTypeDefinition == typeof(IList<>)))
                {
                    type = typeof(List<>).MakeGenericType(modelType.GetGenericArguments());
                }
                return Activator.CreateInstance(type);            
            }
            else if(modelType.IsAbstract)
            {
                string concreteTypeName = bindingContext.ModelName + ".Type";
                var concreteTypeResult = bindingContext.ValueProvider.GetValue(concreteTypeName);
                if (concreteTypeResult == null)
                    throw new Exception("Concrete type for abstract class not specified");
                type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.IsSubclassOf(modelType) && t.Name == concreteTypeResult.AttemptedValue);
                if (type == null)
                    throw new Exception(String.Format("Concrete model type {0} not found", concreteTypeResult.AttemptedValue));
                var instance = Activator.CreateInstance(type);
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => instance, type);
                return instance;
            }
            else
            {
                return Activator.CreateInstance(modelType);
            }
        }
    }
