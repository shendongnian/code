    public void page_Clicked(object sender, EventArgs e)
    {
         Control c = sender as Control;
         MessageBox.Show("Clicked on " + c.Text);
    }
