    DataSet dataSet = ds as DataSet;
    GridViewDataComboBoxColumn column = (ASPxGridView4.Columns["Naam"] as GridViewDataComboBoxColumn);
    column.PropertiesComboBox.DataSource = dataSet.Tables[0];
    column.PropertiesComboBox.ValueField = "SomeValueField";
    column.PropertiesComboBox.ValueType = typeof(int);  // type of the SomeValueField
    column.PropertiesComboBox.TextField = "SomeTextField";
