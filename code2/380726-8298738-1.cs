    protected void Page_PreInit(object sender, EventArgs e)
    {
        DropDownList db = new DropDownList();
        db.Items.Add("Bangalore");
        db.Items.Add("Mandya");
        db.Items.Add( "Hassan");
        db.SelectedIndexChanged += db_SelectedIndexChanged;
        db.AutoPostBack = true;
        tc.Controls.Add(db);
    }
