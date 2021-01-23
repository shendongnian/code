    var z = RadGrid2.MasterTableView.FilterExpression;
                string filter = "";
                if (z.Split('\"').Length > 3)
                {
                    string v = "'" + z.Split('\"')[3] + "'";
                    string c = z.Split('\"')[0];
                    string opr = " like ";
                    c = c.Replace("(iif(", "").Replace(" ", "").Replace("==", "").Replace("null", "").Replace(",", "");
                    filter = c + opr + v ;
                }
                else
                    filter = z;
                
                e.InputParameters["filterExpression"] = filter;
