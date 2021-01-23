    for (I = 0; I <= ds.Tables["EMAILS"].Rows.Count - 1; I++)
    {
        String email = ds.Tables["EMAILS"].Rows[I].Item["email"];
        if (email == GlobalData.Email)
        {
            Label2.Text = GlobalData.Email;
            Label1.Text = GlobalData.Name;
            Label3.Text = GlobalData.LastName;
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
