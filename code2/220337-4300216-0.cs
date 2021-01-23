    private void SaveData(List<cUrlData> SoftwareData)
    {
        try
        {
            using (TextWriter reader = new StreamWriter("data.xml"))
            {
                (new XmlSerializer(typeof(List<cUrlData>))).Serialize(reader, SoftwareData);
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
    private List<cUrlData> LoadData()
    {
        List<cUrlData> mysXmlClass = null;
        try
        {
            using (TextReader reader = new StreamReader("data.xml"))
            {
                object myXmlClass = (object)(new XmlSerializer(typeof(List<cUrlData>))).Deserialize(reader);
                mysXmlClass = (List<cUrlData>)myXmlClass;
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        return mysXmlClass;
    }
