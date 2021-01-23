            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\...\combobox.txt");
                string line = sr.ReadLine();
                while (line != null)
                {
                    comboBox1.Items.Add(line);
                    line = sr.ReadLine();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
