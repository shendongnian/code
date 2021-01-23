            XmlSerializer serializer = new XmlSerializer(typeof(DataSet));
            FileStream fs = new FileStream(yourFilePath, FileMode.Create);
            XmlWriterSettings Settings = new XmlWriterSettings(); //Please use this!
            Settings.Indent = true;
            Settings.IndentChars = "  ";
            Settings.NewLineHandling = NewLineHandling.None;
            Settings.NewLineChars = "\n";
            XmlWriter writer = XmlWriter.Create(fs, Settings); 
            //XmlWriter writer = new XmlTextWriter(fs, Encoding.ASCII);
            serializer.Serialize(writer, ds);
            writer.Close();
            fs.Close();
