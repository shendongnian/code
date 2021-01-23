        public class DictionaryModelBinder : IModelBinder
        {
            /// <summary>
            /// Binds the model to a value by using the specified controller context and binding context.
            /// </summary>
            /// <returns>
            /// The bound value.
            /// </returns>
            /// <param name="controllerContext">The controller context.</param><param name="bindingContext">The binding context.</param>
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                if (bindingContext == null)
                    throw new ArgumentNullException("bindingContext");
    
                string modelName = bindingContext.ModelName;
                // Create a dictionary to hold the results
                IDictionary<string, string> result = new Dictionary<string, string>();
    
                // The ValueProvider property is of type IValueProvider, but it typically holds an object of type ValueProviderCollect
                // which is a collection of all the registered value providers.
                var providers = bindingContext.ValueProvider as ValueProviderCollection;
                if (providers != null)
                {
                    // The DictionaryValueProvider is the once which contains the json values; unfortunately the ChildActionValueProvider and
                    // RouteDataValueProvider extend DictionaryValueProvider too, so we have to get the provider which contains the 
                    // modelName as a key. 
                    var dictionaryValueProvider = providers
                        .OfType<DictionaryValueProvider<object>>()
                        .FirstOrDefault(vp => vp.ContainsPrefix(modelName));
                    if (dictionaryValueProvider != null)
                    {
                        // There's no public property for getting the collection of keys in a value provider. There is however
                        // a private field we can access with a bit of reflection.
                        var prefixsFieldInfo = dictionaryValueProvider.GetType().GetField("_prefixes",
                                                                                          BindingFlags.Instance |
                                                                                          BindingFlags.NonPublic);
                        if (prefixsFieldInfo != null)
                        {
                            var prefixes = prefixsFieldInfo.GetValue(dictionaryValueProvider) as HashSet<string>;
                            if (prefixes != null)
                            {
                                // Find all the keys which start with the model name. If the model name is model.DictionaryProperty; 
                                // the keys we're looking for are model.DictionaryProperty.KeyName.
                                var keys = prefixes.Where(p => p.StartsWith(modelName + "."));
                                foreach (var key in keys)
                                {
                                    // With each key, we can extract the value from the value provider. When adding to the dictionary we want to strip
                                    // out the modelName prefix. (+1 for the extra '.')
                                    result.Add(key.Substring(modelName.Length + 1), bindingContext.ValueProvider.GetValue(key).AttemptedValue);
                                }
                                return result;
                            }
                        }
                    }
                }
                return null;
            }
        }
