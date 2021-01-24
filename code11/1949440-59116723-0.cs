    remcl3.Wcl3Client client = new remcl3.Wcl3Client();
    string rrs = client.getsql("sabatini", "ZXCqwe1920",112, w);            
    
    string xml = @rrs;
    
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    
    XmlNodeList elemList = doc.GetElementsByTagName("AC_NO");
    XmlNodeList elem = doc.GetElementsByTagName("AC_NAME");
    DataTable table = new DataTable();
    table.Columns.Add("AC_NO");
    table.Columns.Add("AC_NAME");
    
    for (int i = 0; i < elemList.Count; i++)
    {
        DataRow row = table.NewRow();
        var value = elemList[i].InnerXml;
        var text = elem[i].InnerXml;
        row["AC_NO"] = value;
        row["AC_NAME"] = text;
        table.Rows.Add(row);
    }
    // Configure your Dropdownlist
    rem_no.DataSource = table;
    rem_no.ValueMember = "AC_NO";
    rem_no.DisplayMember = "AC_NAME";
    rem_no.SelectedIndex = -1;
