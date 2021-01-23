    string index = ComboBoxDB.Text;
            if (index.Equals(""))
            {                
                MessageBox.Show("your message");
            }
            else
            {
                openFileDialog1.ShowDialog();
                string file = openFileDialog1.FileName;
                reader = new StreamReader(File.OpenRead(file));
            }
