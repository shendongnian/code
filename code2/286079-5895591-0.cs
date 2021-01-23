    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        Form3 NwMdiChild2 = new Form3();    //don't forget ()
        NwMdiChild2.MdiParent = this;
        NwMdiChild2.Dock = System.Windows.Forms.DockStyle.Fill;
        NwMdiChild2.Show();
    }
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
        //if no MDI child - this is going to be skipped and norlmal Form2 close takes place
        if (this.MdiChildren.Length > 0)    //close childrens only when there are some
        {
            foreach (Form childForm in this.MdiChildren)
                childForm.Close();
            e.Cancel = true;  //cancel Form2 closing
        }
    }
