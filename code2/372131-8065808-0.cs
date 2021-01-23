    private void Save<T>(T object, string path)
    {
        try
        {
            using (var writer = new StreamWriter(path))
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(object.GetType());
                x.Serialize(writer, settings);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error Saving " + typeof(T).Name + " File " + ex.ToString());
            return;
        }
    }
