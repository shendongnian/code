    for (int i = 0; i < tempValues.Length; i++)
    {
        var pattern = string.Format(@"(\[{0}\])", i);
        Data = Regex.Replace(Data, pattern, tempValues[i].ToString());
    }
