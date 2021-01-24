    List<string> Transpoters = new List<string>();
                    StringBuilder sb = new StringBuilder();
                    foreach (ListItem item in TransporterDropDownList1.Items)
                    {
                        if (item.Selected) { 
        
                            Transpoters.Add("'"+item.Value+"'");
                            sb.Append("'"+item+"'").Append(",");
                        }
                    }
                    string test = sb.ToString();
