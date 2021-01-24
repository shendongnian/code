    private void button1_Click(object sender, EventArgs e)
        {
            Form2 newofrm = new Form2();//new instance
            newofrm.TopLevel = false;//allow to added to panel
            this.panel1.Controls.Add(newofrm);// add to panel
            newofrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;// remove boarder
            newofrm.Dock = DockStyle.Fill;// completely fill panel
            newofrm.Show();// show the form
        }
 
