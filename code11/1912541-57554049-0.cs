    for (int i = 0; i < 5; i++)
    {
        XmlElement element2 = finalDoc.CreateElement(string.Empty,"song", string.Empty);
        element2.SetAttribute("title", "title" + i);
        for (int k=0; k<5;k++)
        {
            XmlElement element3 = finalDoc.CreateElement(string.Empty, "line", string.Empty);
            element3.InnerText = "text " + k;
            element2.AppendChild(element3);
        }
        element1.AppendChild(element2);
    }
