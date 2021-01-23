    using (var reader = XmlReader.Create(uploadedFile.InputStream))
    {
        try
        {
            while (reader.Read())
            { }
            // At this stage you may save the XML file into the database. 
        }
        catch (Exception ex)
        {
            // probably not a valid XML file
        }
    }
