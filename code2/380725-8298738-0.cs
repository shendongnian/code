    protected void Page_PreInit(object sender, EventArgs e)
    {
        DropDownList db = new DropDownList();
        db.Items.Add("Bangalore");
        db.Items.Add("Mandya");
        db.Items.Add( "Hassan");
        tc.Controls.Add(db);
    }
