    List<string> options = new List<string>();
    List<string> values = new List<string>();
    options.Add("option1");
    values.Add("value1");
    options.Add("option2");
    values.Add("value2");
    StringBuilder queryString = new StringBuilder();
    for (int i = 0; i < options.Count; i++)
    {
        if (queryString.Length > 0)
            queryString.Append(" Or ");
        queryString.Append(string.Format("(datakey = \"{0}\" And dataValue = \"{1}\")", options[i], values[i]));
    }
    var query = context.YourTable.Where(queryString.ToString());
