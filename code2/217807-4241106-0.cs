    DataTable dt = new DataTable();
    string qry = "select ID , Name from xmlTB";
    SqlDataReader reader = db.select_data(qry);
    dt.Columns.Add["ID"];
    while (reader.Read())
    {
    	string xmlString = reader[1].ToString();
    	string id = reader[0].ToString();
    	XDocument document = XDocument.Parse(xmlString);
    	//ensure datatable contains a column for each attribute:
    	foreach (XElement el in document.Root.Elements())
    	{
    		foreach (XAttribute attribute in el.Attributes())
    		{  
    			if (!dt.Columns.Contains(attribute.Name.LocalName))
    			{
    				dt.Columns.Add(new DataColumn(attribute.Name.LocalName, typeof(string)));
    			}
    		}
    	}
    	DataRow dr = dt.NewRow();
    	//set each value in the datarow:
    	foreach (XElement el in document.Root.Elements())
    	{
    		foreach (XAttribute attribute in el.Attributes())
    		{
    			dr[attribute.Name.LocalName] = attribute.Value;
    		}
    	}
    	dr["ID"] = id;
    	dt.Rows.Add(dr);
    }
    
    //Bind the gridview to the datasource:
    this.dataGridView1.DataSource = dt;
    //*The above assumes your GridView is named dataGridView1.
