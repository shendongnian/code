    //Read the teachers element from xml schema file
    XElement teachers = XDocument.Load(schemaFile).Descendants("teachers").SingleOrDefault();
    
    if (teachers != null)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("id");
        dt.Columns.Add("name");
        
    
        dt.Rows.Add("1", "john");
        dt.Rows.Add("2", "philips");
        dt.Rows.Add("3", "sara");
    
        XDocument doc = new XDocument();
        foreach (DataRow row in dt.Rows)
        {
            XElement teacher = new XElement("teacher");
            teacher.SetAttributeValue("id", row["id"]);
            teacher.SetAttributeValue("name", row["name"]);
            teacher.SetAttributeValue("short", row["name"].ToString().Substring(0,2));
            
            teachers.Add(teacher);
        }
        doc.Add(teachers);
        doc.Save(newFilename);
     }
   
