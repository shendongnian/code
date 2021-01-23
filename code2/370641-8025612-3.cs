    public string arrayToString(System.Collections.ArrayList ar)
    {
        StringBuilder sb = new StringBuilder();
        System.Xml.XmlWriterSettings st = new System.Xml.XmlWriterSettings();
        st.OmitXmlDeclaration = true;
        st.Indent = false;
        System.Xml.XmlWriter w = System.Xml.XmlWriter.Create(sb, st);
        System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(ar.GetType());
        s.Serialize(w, ar);
        w.Close();
        return sb.ToString();        
    }
    public static void SaveArraytoFile(System.Collections.ArrayList ar, string fileName)
    {
        using (System.IO.StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (var item in ar)
            {
                sw.WriteLine(item);
            }
        }
    }
