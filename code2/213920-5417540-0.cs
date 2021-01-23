            var propertyInfoArray = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in propertyInfoArray)
            {
                var propValue = propertyInfo.GetValue(obj, null);
                if (propValue == null) continue;
                if (propValue.GetType().Name == "String")
                {
                    propertyInfo.SetValue(obj, ((string)propValue).Trim(), null);
                }
            }
        }
