    public static class Extensions
    {
        public static JToken RemoveIntegerFields(this JToken token)
        {
            JContainer container = token as JContainer;
            if (container == null) return token;
            List<JToken> removeList = new List<JToken>();
            foreach (JToken el in container.Children())
            {
                JProperty p = el as JProperty;
                if(p!=null && p.Value.Type == JTokenType.Integer)
                {
                    removeList.Add(el);
                }
                el.RemoveIntegerFields();
            }
            foreach (JToken el in removeList)
            {
                el.Remove();
            }
            return token;
        }
    }
