           public void writeToXML(DataTable inputData, string fileName) {
            XmlSerializer xml = new XmlSerializer(typeof(DataTable));
            StreamWriter sw = new StreamWriter(fileName);
            xml.Serialize(sw, inputData);
            sw.Close();
       }
