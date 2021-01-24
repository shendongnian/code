    private void DeleteSubjectButton_Click(object sender, RoutedEventArgs e)
    {
        XmlDocument document = new XmlDocument();
        document.Load(xmlLocation);
        foreach (XmlNode node in document.SelectNodes("Subjects/Subject"))
        {
            if (node.InnerText == selectedSubjectItem)
            {
                node.ParentNode.RemoveChild(node);
            }
        }
        document.Save(xmlLocation);
    }
