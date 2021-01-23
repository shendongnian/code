    protected void Button1_Click(object sender, EventArgs e)
    {
        string email = email.Text;
        //Check database etc
        
        HtmlInputHidden hidden = new HtmlInputHidden();
        hidden.Value = email;
        hidden.ID = "hiddenemail";
        form1.Controls.Add(hidden); // Where form1 is the ID of a form with runat=server
    }
