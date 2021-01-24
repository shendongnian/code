    foreach (XmlNode node in document.SelectNodes("/Subjects/Subject"))
    {
        if (node.InnerText == selectedSubjectItem)
        {
            node.ParentNode.RemoveChild(node);
        }
    }
