    foreach (GridViewRow row in GridView1.Rows)
    {
        TextBox txt = row.FindControl("TextBox1") as TextBox;
        if (txt != null)
        {
            string value = txt.Text;
        }
    }
