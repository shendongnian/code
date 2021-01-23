        txtEmail.DataBindings.Add("Text", "", "Email");
        txtID.DataBindings.Add("Text", "", "ID");
        txtName.DataBindings.Add("Text", "", "Name");
        DataTable DT = BL.GetDataTable();
        bSource.DataSource = DT;
        DR.DataSource = bSource;
