            var dictionary = new ExpandoObject() as IDictionary<string, object>;
            foreach (var propertyInfo in item.GetType().GetProperties())
            {
                dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(item, null));
            }
            return (ExpandoObject)dictionary;
        }
