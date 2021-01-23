        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Files> yourNewList = Files.GetFiles();
            List<String> u = new List<string>();
            if (comboBox1.Text == "Month")
            {
                u = (from Files f in yourNewList
                     where DateTime.Parse(f.CreationDate.Substring(0, 10)) > DateTime.Now.AddMonths(-1)
                     select f.FileName).ToList();
            }
            else if (comboBox1.Text == "3 Month")
            {
                u = (from Files f in yourNewList
                     where DateTime.Parse(f.CreationDate.Substring(0, 10)) > DateTime.Now.AddMonths(-3)
                     select f.FileName).ToList();
            }
            else if (comboBox1.Text == "1 Year")
            {
                u = (from Files f in yourNewList
                     where DateTime.Parse(f.CreationDate.Substring(0, 10)) > DateTime.Now.AddMonths(-12)
                     select f.FileName).ToList();
            }
            
            listBox1.DataSource = u;
        }
