     public class person
    {
        public string name{ get; set; }
        public int id { get; set; }
    }
        person p = new person("Ali", 1);
        List<person> plist = new List<person>();
        plist.Add(p);
         
        DataTable dt = new DataTable();
          dt.TableName = "People";
          dt.Columns.Add("Name");
          dt.Columns.Add("ID");
                
            foreach(var item in plist)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count-1]["Name"] = item.name;
                dt.Rows[dt.Rows.Count - 1]["ID_Code"] = item.id_cod;
              
               
            }
            dt.WriteXml("test.Xml");
