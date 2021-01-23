    var classNodes = doc.SelectNodes("/Sections/Classes/Class");
    // LINQ approach
    string[] classes = classNodes.Cast<XmlNode>()
                                 .Select(n => n.InnerText)
                                 .ToArray();
    
    var studentNodes = doc.SelectNodes("/Sections/Students/Student");
    // traditional approach
    string[] students = new string[studentNodes.Count];
    for (int i = 0; i < studentNodes.Count; i++)
    {
        students[i] = studentNodes[i].InnerText;
    }
