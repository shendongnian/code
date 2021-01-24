       List<code> codes = new List<code>();
                        string[] s = File.ReadAllLines(ofdl.FileName);
    
                        string textfile = ofdl.FileName;
                           var textvalues = s;
    
                           foreach (var item in textvalues)
                           {
                           codes.Add(new code() { Value = item});
                           }
                        dataGrid.ItemsSource = codes;
                             
    
    
                    }
                }
            }
    
            private void streams()
            {
    
    
            }
    
            private string RemoveEmptyLines(string lines)
            {
                return lines = Regex.Replace(lines, @"\n\s.+", "");
            }
