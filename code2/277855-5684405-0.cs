    Regex re = new Regex("First Pattern|Second Pattern|Super(Mega)*Delux", RegexOptions.IgnoreCase);
    source = re.Replace(source, delegate(Match m)
    {
        string value = m.Value;
        if(value.Equals("first pattern", StringComparison.OrdinalIgnoreCase)
        {
            return "1st";
        }
        else if(value.Equals("second pattern", StringComparison.OrdinalIgnoreCase)
        {
            return "2nd";
        }
        else
        {
            return "";
        }
    });
