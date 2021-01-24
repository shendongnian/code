    string[] lines = File.ReadAllLines("D:\\file.cfg");    
                if (index < lines.Length)    
                {     
                    textbox1.Text = new String(lines[index++].Where(x => Char.IsDigit(x)).ToArray());    
                    textboxt2.Text = new String(lines[index++].Where(x => Char.IsDigit(x)).ToArray());    
                    textbox3.Text = new String(lines[index++].Where(x => Char.IsDigit(x)).ToArray());        
                }
