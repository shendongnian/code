        protected void Button1_Click(object sender, EventArgs e)
       {
         TableRow tb = new TableRow();
         TableCell tc = new TableCell();
         DropDownList db = new DropDownList();
        db.Items.Add("Bangalore");`
        db.Items.Add("Mandya");
        db.Items.Add( "Hassan");
        tc.Controls.Add(db);
        tb.Controls.Add(tc);
 
       Table1.Controls.Add(tb);
       db.SelectedIndexChanged += db_SelectedIndexChanged;
       db.AutoPostBack = true;
       db_SelectedIndexChanged(null,null); // use this line, i hope it will work now.
    
      }
      private void db_SelectedIndexChanged(object sender, EventArgs e)
      {
        label.text = "welcome";
      }
 
