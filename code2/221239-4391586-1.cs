    foreach (Element elem in elemSet)
    {
        Parameter param = elem.get_Parameter(paramName);
        if (param != null)
        {
            var similar = elemparam.SimilarObjectTypes;
            foreach (Element choice in similar)
            {
                string ChoiceName = choice.Name;
            }
        }
    }
