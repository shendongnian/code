    using(var reader = XmlReader.Create(stream))
    {
        while(!reader.EOF)
        {
            reader.Read();
            
            if(reader.IsEmptyElement)
            {
                ...
            }
        }
    }
