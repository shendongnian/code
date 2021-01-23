    Form2 _form2;
    private void customer_clicked(object sender, EventArgs e)
    {
        _form2 = new Form2();
        _form2.MdiParent = this;
        _form2.MaximizeBox = true;
        _form2.Show();
    }
    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // a NullReference is still possible if this is called before customer_clicked
        _form2.writeX();
    }
