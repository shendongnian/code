    using (AsfFile asfFile = new AsfFile(sampleFileName))
    {
        //Get bitrate
        uint asfBitRate = asfFile.PacketConfiguration.AsfBitRate;
        Console.WriteLine("Bitrate :" + asfBitRate);
        //Get language
        var languageObject = (AsfLanguageListObject)asfFile.GetAsfObjectByType(AsfGuid.ASF_Language_List_Object).FirstOrDefault();
        if (languageObject != null)
        {
            foreach (string language in languageObject.Languages)
                Console.WriteLine("Language: " + language);
        }
        //Get Metadata
        var metadataObject = (AsfMetadataObject)asfFile.GetAsfObjectByType(AsfGuid.ASF_Metadata_Object).FirstOrDefault();
        if (metadataObject != null)
        {
            foreach (var item in metadataObject.DescriptionRecords)
                Console.WriteLine(string.Format("{0} has value {1} (applies to stream #{2})", item.Name, item.Value, item.StreamNumber));
        }
    }
