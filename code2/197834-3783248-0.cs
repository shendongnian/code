    public string ToCsv()
    {
        IEnumerable<string> props = GetProperties();
        using (StringWriter sw = new StringWriter())
        {
            sw.WriteLine(GetHeadings(props));
            WriteValues(props, sw);
            return sw.ToString();
        }
    }
