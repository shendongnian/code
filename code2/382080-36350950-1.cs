        T t0 = new T();
           t0.id=1;
           t0.property1="John";
           t0.property2="Doe";
        List<T> Tlist = new List<T>();
           Tlist.Add(t0);
         
        DataTable dt = new DataTable();
           dt.TableName = "People";
           dt.Columns.Add("ID");
           dt.Columns.Add("Name");
           dt.Columns.Add("Lastname");
                
            foreach(var item in tlist)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count-1]["ID"] = item.name;
                dt.Rows[dt.Rows.Count - 1]["Name"] = item.id_cod;
                dt.Rows[dt.Rows.Count - 1]["Lastname"] = item.id_cod;
              
               
            }
            dt.WriteXml("test.Xml");
