       private Dictionary<string, string> getRelationPropertyAttribute(Type type)
        {
            var dicRelation = new Dictionary<string, string>();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(inherit: false);
                var customAttributes = attributes
                    .AsEnumerable()
                    .Where(a => a.GetType() == typeof(MongoDBFieldAttribute));
                if (customAttributes.Count() <= 0)
                    continue;
                foreach (var attribute in customAttributes)
                {
                    if (attribute is MongoDBFieldAttribute attr) 
                        dicRelation[attr.Field] = property.Name;
                }
            }
            return dicRelation;
        }
