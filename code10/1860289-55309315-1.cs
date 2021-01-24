    public static class Extensions
    {
        public static JToken RemoveFieldTypes(this JToken token,params JTokenType []fieldTypes)
        {
            JContainer container = token as JContainer;
            if (container == null) return token;
    		
            var tokensToRemove = new List<JToken>();
            foreach (JToken el in container.Children())
            {
                JProperty p = el as JProperty;
                if(p!=null && fieldTypes.Contains(p.Value.Type))
                {
                    tokensToRemove.Add(el);
                }
                el.RemoveFieldTypes(fieldTypes);
            }
            foreach (JToken el in tokensToRemove)
            {
                el.Remove();
            }
            return token;
        }
    }
