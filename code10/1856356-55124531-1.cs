    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("Checked", typeof(bool)) { DefaultValue = false });
    ...
----------
    <CheckBox Content="{Binding tag}" IsChecked="{Binding Checked} "/>
