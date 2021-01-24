    while(line != null)
            {
                line = sr.ReadLine();
                if (line[0].Equals("B") || line[0].Equals("b"))
                {
                    performListBox.Items.Add(line);
                }
                   //performListBox.Items.Add(line);
            }
