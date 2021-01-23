    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Response.Redirect("~/Newpage.aspx?no=" + txtNo.Text + "&name=" + txtName.Text); 
        }
    }
