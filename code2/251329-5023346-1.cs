void comboBox_Format(object sender, ListControlConvertEventArgs e)
{
        DataRowView cityRow = e.ListItem as DataRowView;
        string city = cityRow["name"].ToString();
        DataRow countryRow = cityRow.Row.GetParentRow("parentRelation");
        string country = countryRow["name"].ToString();
        e.Value = city + " " + country;
}
