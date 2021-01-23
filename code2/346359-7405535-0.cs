    string[] fileEntries = Directory.GetFiles(@"c:\Sciclone UAC", "*.cfg*");
            foreach (string fileName in fileEntries)
            {
                XDocument doc = XDocument.Load(fileName);
                var query = from x in doc.Descendants("XAxisCalib")
                            select new
                            {
    
                                MaxChild = x.Descendants("Max"),
                                MinChild = x.Descendants("Min")
                            };
              /*  {
                    var bs1 = new BindingSource { DataSource = query };
    
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.AutoSize = true;
    
                    dataGridView1.DataSource = bs1;
                }*/
    
    
                var query2 = from y in doc.Descendants("YAxisCalib")
    
                             select new
                             {
    
                                 MaxChild = y.Descendants("Max"),
                                 MinChild = y.Descendants("Min")
    
                             };
    
    
              /*  var bs2 = new BindingSource { DataSource = query2 };
    
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.AutoSize = true;
    
                dataGridView1.DataSource = bs2;*/
    
    
                var query3 = from z in doc.Descendants("ZAxisCalib")
    
                             select new
                             {
    
                                 MaxChild = z.Descendants("Max"),
                                 MinChild = z.Descendants("Min")
                             };
    
                var bs3 = new BindingSource { DataSource = query.Union(query2.Union(query3)) };
    
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.AutoSize = true;
    
                dataGridView1.DataSource =bs3;
    
            }
