    using (var reader = new XmlReader(...))
    {
        while reader.Read()
        {
            if (reader.Name = "book" && reader.IsStartElement)
            {
                // endless, confusing nesting!!!
            }
        }
    }
