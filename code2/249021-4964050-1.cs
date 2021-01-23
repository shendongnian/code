    public void DumpToConsole(IFormatter<DataField> formatter = null)
    {
        // Perhaps you could specify a default. Up to you.
        formatter = formatter ?? Formatter<DataField>.Default;
        foreach (DataField field in m_fields)
        {
            Console.WriteLine(formatter.Format(field));
        }
    }
