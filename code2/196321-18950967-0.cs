    String strXML = "<reply success=\"true\">More nodes go here</reply>";
        using (XmlReader reader = XmlReader.Create(new StringReader(strXML)))
        {
                reader.ReadToFollowing("reply");
                reader.MoveToContent();
                string strValue = reader.GetAttribute("success");
                Console.WriteLine(strValue);
        }
