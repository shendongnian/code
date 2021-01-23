    using (var reader = XmlReader.Create(stringz, readerSettings))
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        while (reader.Read())
        {
            using (var fragmentReader = reader.ReadSubtree())
            {
                if (fragmentReader.Read())
                {
                    reader.ReadToFollowing("value");
                    sb.Append(reader.ReadElementContentAsString()).Append(",");
                }
            }
        }
        Console.WriteLine(sb.ToString());
    }        
