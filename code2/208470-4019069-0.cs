    XmlNodeList xnlInsuredListMembers = xDoc.SelectNodes("//InsuredListMember");
    foreach (XmlNode xnMember in xnlInsuredListMembers)
    {
        XmlNode xnHomeAddress = xnMember.SelectNode("HomeAddress");
        string sHomeAddress = xnHomeAddress.InnerText;
    
        XmlNode xnName = xnMember.SelectNode("Name");
        string sName = xnName.InnerText;
    
        saveMember(sName, sHomeAddress);
    }
