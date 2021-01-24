    static void Main(string[] args)
    {
        var json =
            @"{
               ""Footer"": ""footer"",
                    ""RowType"": 4,
                    ""answers"": 
                    [
                        {
                            ""answer"": 1,
                            ""FooterInner"": ""innerfooter""
                        },
                        {
                            ""answer"": 2,
                            ""FooterInner"": ""innerfooter2""
                        }
                    ]
                }";
        JToken nodeList = JToken.Parse(json);
        List<JTokenType> typesToRemove = new List<JTokenType>(){JTokenType.Boolean, JTokenType.Float, JTokenType.Integer};
    
        removeFields(nodeList, typesToRemove);
    
        Console.WriteLine(nodeList.ToString());
        Console.ReadKey();
    }
    
    private static void removeFields(JToken token, List<JTokenType> typesToRemove)
    {
        JContainer container = token as JContainer;
        if (container == null) return;
    
        List<JToken> removeList = new List<JToken>();
        foreach (JToken el in container.Children())
        {
            JProperty p = el as JProperty;
            if (p != null && typesToRemove.Contains(p.Value.Type))
            {
                removeList.Add(el);
            }
    
            removeFields(el, typesToRemove);
        }
    
        foreach (JToken el in removeList)
        {
            el.Remove();
        }
    }
