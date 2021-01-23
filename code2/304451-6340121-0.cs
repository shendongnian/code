    private void Editbuildstreams_Click(object sender, RoutedEventArgs e)
    {
        BuildstreamTextblock.Visibility = Visibility.Visible;
        XmlDocument doc = new XmlDocument();
        using (XmlTextReader reader = new XmlTextReader("initial.xml"))
        {
           reader.Read(); 
           doc.Load(reader);
           
           StringBuilder line = new StringBuilder();
           line.apend (doc.doc.GetElementsByTagName("buildstream1")[0].outerXml;
           BuildstreamTextblock.Text = line;
        }
    }
