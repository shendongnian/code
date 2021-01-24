     while ((line = sr.ReadLine()) != null)
                {
                    string[] components = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if( components.Contains(username))
                      {
                         curbal = string.Join(" ", components[5]);
                         label3.Text = curbal;
                         savbal = string.Join(" ", components[6]);
                         label5.Text = savbal;
                       }
              
                }
                sr.Close();
