    ReadReg(@"Software\BilkerSoft", key =>
            {
                textBox1.Text = key.GetValue("SQLSERVER").ToString();
            },key =>
            {
                textBox2.Text = key.GetValue("DATABASE").ToString();
            },key =>
            {
                textBox3.Text = key.GetValue("USER").ToString();
            },key =>
            {
                textBox4.Text = key.GetValue("PASSWORD").ToString();
            });
