        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fm == null|| fm.Text=="")
            {
                fm = new Form1();              
                fm.MdiParent = this;
                fm.Dock = DockStyle.Fill;
                fm.Show();
            }
            else if (CheckOpened(fm.Text))
            {
                fm.WindowState = FormWindowState.Normal;
                fm.Dock = DockStyle.Fill;
                fm.Show();
                fm.Focus();               
            }                   
        }
