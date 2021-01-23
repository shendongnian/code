        void SaveAsXmlToFile(object o, string fname)
        {
            XmlSerializer ser = new XmlSerializer(o.GetType());
            using (var f = File.Open(fname, FileMode.OpenOrCreate))
                ser.Serialize(f, o);
        }
