        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> t = Directory.GetFiles(@"C:\Users\justin\Desktop\New folder (2)").ToList();
            List<String> y = new List<string>();
            List<String> u = new List<string>();
            foreach (var zzz in t)
            {
                y.Add(Path.GetFileName(zzz));
            }
            if (comboBox1.Text == "Month")
            {
                u =
               (from String s in y where ((DateTime.Now.Month - DateTime.Parse(s.Substring(8, 10)).Month) < 1) && (DateTime.Now.Year - DateTime.Parse(s.Substring(8, 10)).Year == 0) select s).
                   ToList();
            }
            else if (comboBox1.Text == "3 Month")
            {
                u =
               (from String s in y where ((DateTime.Now.Month - DateTime.Parse(s.Substring(8, 10)).Month) < 3) && (DateTime.Now.Year - DateTime.Parse(s.Substring(8, 10)).Year == 0) select s).
                   ToList();
            }
            else if(comboBox1.Text == "1 Year")
            {
                u =
               (from String s in y where ((DateTime.Now.Month - DateTime.Parse(s.Substring(8, 10)).Month) < 12) select s).
                   ToList();
            }
            
            listBox1.DataSource = u;
        }
