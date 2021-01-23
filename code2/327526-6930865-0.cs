    private void button24_Click(object sender, EventArgs e)
    {
        //DELETE
        string t = tbSelected.Text;
        if (t.Length > 0)
        {
            tbSelected.Text = t.Remove(t.Length - 1);
        } 
    }
