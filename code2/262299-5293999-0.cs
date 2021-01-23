    protected void Button1_Click(object sender, EventArgs e){
        Response.Redirect("~/page2.aspx?showButton=true", true);
    }
    protected void Button2_Click(object sender, EventArgs e){
        Response.Redirect("~/page2.aspx?showButton=false", true);
    }
