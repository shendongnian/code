             string[] sExcelString3 = { "Vessel Name :", "Voyage No. :", "Port :", "Terminal :", "NMC Global File :","Line : ","ETA : ","Total Container : " };
          //ItemArray);
      var w = (from p in ds.Tables["ReadExcel"].Rows.Cast<DataRow>().ToArray() select p.ItemArray).ToList();
        
          foreach (string item in sExcelString2)
                    {
                        var r3 = (from c in w
                                 where c.Any(e => e.ToString().Contains(item))
                                 select c).ToList();
        
                         System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(item);
                         foreach (var it in r3)
                         {
        //                     int r = it.ToList().FindIndex(p => regEx.IsMatch(p.ToString()));
        string result =r3[ it.ToList().FindIndex(p => regEx.IsMatch(p.ToString()))+1];
                         }
                         
                            
                         
                       
                    }
