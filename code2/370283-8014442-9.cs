    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            TextBox txt = row.FindControl("TextBox1") as TextBox;
            if (txt != null)
            {
                //get the value from the textbox
                string value = txt.Text;
            }
        }
    }
