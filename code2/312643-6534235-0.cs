    string rawDate = "2011-06-27T14:03:19.5300000+07:00";
    DateTime dt = DateTime.MinValue;
    if (!DateTime.TryParse(rawDate, out dt))
    {
        Debug.WriteLine("Unable to parse");
    }
