    public List<JToken> GetSubTermsByTermName(string type, string termName)
    {
        var termSetTerms =
            from t in Terms
            where (string)t["type"].First == type
            select t;
        List<JToken> subClasses = new List<JToken>();
        foreach (var rootTerm in termSetTerms)
        {
            if (rootTerm["sub_class_of"].Count() > 0)
            {
                foreach(var subClassOf in rootTerm["sub_class_of"])
                {
                    if ((string)subClassOf["label"] == termName)
                    {
                        subClasses.Add(rootTerm);
                    }
                }
            }
        }
        return subClasses;
    }
