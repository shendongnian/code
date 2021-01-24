        public static class JsonExtensions
        {        
            public static void Rename(this JToken token, string newName)
            {
                if (token == null)
                    throw new ArgumentNullException("token", "Cannot rename a null token");
                JProperty property;
                if (token.Type == JTokenType.Property)
                {
                    if (token.Parent == null)
                        throw new InvalidOperationException("Cannot rename a property with no parent");
                    property = (JProperty)token;
                }
                else
                {
                    if (token.Parent == null || token.Parent.Type != JTokenType.Property)
                        throw new InvalidOperationException("This token's parent is not a JProperty; cannot rename");
                    property = (JProperty)token.Parent;
                }
                var newProperty = new JProperty(newName, property.Value);
                property.Replace(newProperty);
            }
        }
