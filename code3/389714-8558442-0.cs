    public DataTable getSections() {
            String url = "http://<site_url>/sections.xml/sections.xml";
            DataTable t = new DataTable();
            t.Columns.Add("id", typeof(String));
            t.Columns.Add("name", typeof(String));
    
            HttpHandler handle = new HttpHandler();
            StreamReader sr = handle.executeGET(url);
            String xml = "";
            List<String> id = new List<string>();
            List<String> name = new List<string>();
            
            while (sr.Peek() >= 0)
            {
                xml  += sr.ReadLine();
            }
            XmlDataDocument doc = new XmlDataDocument();
            doc.LoadXml(xml);
            XmlReader xmlReader = new XmlNodeReader(doc);
            while (xmlReader.Read()){
                if (xmlReader.IsStartElement()) {
                    String b = xmlReader.Name;
                    switch (xmlReader.Name) { 
                        case "sections":
                            break;
                        case "section":
                            break;
                        case "id":
                            if (xmlReader.Read())
                            {
                                id.Add(xmlReader.Value.Trim());
                            }
                            break;
                        case "name":
                            if (xmlReader.Read())
                            {
                                name.Add(xmlReader.Value.Trim());
    
                            }
                            break;
    
                    }
                }
            }
    
            int counter = 0;
            
            foreach (String i in id) {
                DataRow r = t.NewRow();
                r["id"] = i;
                r["name"] = name[counter];
                t.Rows.Add(r);    
                counter += 1;
            }
            return t;
        }
