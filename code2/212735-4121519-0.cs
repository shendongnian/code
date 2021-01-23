    private void button1_Click(object sender, EventArgs e)
    {
         Form2 f2 = new Form2();
         f2.MdiParent = form1;
         f2.Show();
         button1.Visible = false; // This will cause your button to be hidden.
    }
