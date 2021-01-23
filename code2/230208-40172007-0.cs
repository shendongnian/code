     var data = objDb.TableName.GroupBy(dt => dt.ColumnName).Select(dt => new { dt.Key }).ToList();
    
                foreach (var item in data)
                {
                    var data2= objDb.TableName.Where(dt=>dt.ColumnName==item.Key).Select(dt=>new {dt.SelectYourColumn}).Distinct().FirstOrDefault();
    
                   //Eg.
                    {
                           ListBox1.Items.Add(data2.ColumnName);                    
                    }
    
                }
