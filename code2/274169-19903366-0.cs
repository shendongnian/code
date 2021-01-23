    private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.TopLevel = false;
            f1.AutoScroll = true;
            panel1.Controls.Add(f1);
            f1.Dock = DockStyle.Left;
            f1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            f1.Show();
            //form2
            Form3 f2 = new Form3();
            f2.TopLevel = false;
            f2.AutoScroll = true;
            panel1.Controls.Add(f2);
            f2.Dock = DockStyle.Left;
            f2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            f2.Show();
        }
