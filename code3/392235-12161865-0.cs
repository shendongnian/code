    ASPxComboBox1.ValueField = "ID";
    ASPxComboBox1.ValueType = typeof(String);
    ASPxComboBox1.DataSource = DataTableWithIDandNameColumns;
    ASPxComboBox1.DataBind();
    
    String theID = Convert.ToString(ASPxComboBox1.Value);//The column in the datasource that is specified by the ValueField property.
       OR:
    String theID = Convert.ToString(ASPxComboBox1.SelectedItem.GetValue("ID"));//Any column name in the datasource.
       Also:
    String theName= Convert.ToString(ASPxComboBox1.SelectedItem.GetValue("Name"));
