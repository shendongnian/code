     private void button1_Click(object sender, EventArgs e)
            {
                bool chk,chk1;
                int chkq;
                chk = int.TryParse(textBox1.Text, out chkq);
                chk1 = int.TryParse(textBox2.Text, out chkq);
                if (chk1 && chk)
                {
                    double a = Convert.ToDouble(textBox1.Text);
                    double b = Convert.ToDouble(textBox2.Text);
                    double c = a + b;
                    textBox3.Text = Convert.ToString(c);
                }
                else
                {
                    string f, d,s;
                    f = textBox1.Text;
                    d = textBox2.Text;
                    s = f + d;
                    textBox3.Text = s;
                }
            }
