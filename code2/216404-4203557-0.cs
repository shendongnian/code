    void SubmitBtn_Click(object sender, EventArgs e) 
    {
        HtmlGenericControl foo = this.Master.FindControl("foo");
        foo.Visible = false; 
    }
