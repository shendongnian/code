    XmlNodeList xnlInsuredListMembers = xDoc.SelectNodes("//InsuredListMember");
    foreach (XmlNode xnMember in xnlInsuredListMembers)
    {
        XmlNode xnHomeAddress = xnMember.SelectSingleNode("HomeAddress");
        string sHomeAddress = xnHomeAddress.InnerText;
    
        XmlNode xnName = xnMember.SelectSingleNode("Name");
        string sName = xnName.InnerText;
    
        saveMember(sName, sHomeAddress);
    }
