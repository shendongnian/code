    ComboBox cbDepartment = new ComboBox();
    cbDepartment.Name = "cbDepartment";
    cbDepartment.DataSource = dsDepartments;
    cbDepartment.SelectedIndexChanged = new System.EventHandler(cbDepartment_SelectedIndexChanged);
    private void cbDepartment_SelectedIndexChanged(object sender, System.EventArgs e) {
        cbSection.DataSource = GetSection(cbDepartment.SelectedItem.Value);
    }
