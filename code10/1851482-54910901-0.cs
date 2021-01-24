               var expando = new ExpandoObject();
               IDictionary<string, object> dictionary = (IDictionary<string, object>)expando;
               foreach (var property in source.GetType().GetProperties())
               {
                   string propertyName = property.Name;
                   var propertValue = property.GetValue(source);
                   dictionary.Add(propertyName, propertValue);
               }
               destination.Add(dictionary);
            }
