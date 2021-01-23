        System.IO.MemoryStream xmlStream = new System.IO.MemoryStream();
        StreamWriter writer = new StreamWriter(xmlStream);
        writer.Write(data);
        writer.Flush();
        xmlStream.Position = 0;//Add this to reset the position of the stream.
