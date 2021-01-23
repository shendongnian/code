    WriteReg(@"Software\BilkerSoft", key =>
                {
                    key.SetValue("SQLSERVER", textBox1.Text);
                }, key =>
                {
                    key.SetValue("DATABASE", textBox2.Text);
                }, key =>
                {
                    key.SetValue("USER", textBox3.Text);
                }, key =>
                {
                    key.SetValue("PASSWORD", textBox4.Text);
                });
