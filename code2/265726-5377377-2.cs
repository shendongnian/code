        var dt = New DataTable()
        dt.Columns.Add("email_id");
        dt.Rows.Add("first");
        dt.Rows.Add("second");
        dt.Rows.Add("thrid");
        dt.Rows.Add("fourth");
        var lst = New System.Web.UI.WebControls.ListBox;
        lst.DataSource = dt;
        lst.DataTextField = "Email_ID";
        lst.DataBind();
        //lst.SelectedItem is null here
        lst.SelectedIndex = 1;
        //lst.SelectedItem is NOT null here
