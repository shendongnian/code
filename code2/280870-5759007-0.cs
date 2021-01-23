     private void button1_Click(object sender, EventArgs e)
            {
                string text = textBox1.Text;
                FontFamily ff = GetRandomFont();
                Font fnt = new Font(ff, 12, FontStyle.Bold | FontStyle.Italic);
                textBox2.Font = fnt;
                textBox3.Font = fnt;
                textBox2.Text = textBox1.Text;
                textBox3.Text = textBox1.Text;
            }
    
            private FontFamily GetRandomFont()
            {
                    FontFamily[] ff = System.Drawing.FontFamily.Families;
                    Random rnd = new Random();
                    int num = rnd.Next(ff.Length);
                    return ff[num];
            }
