if (listBox3.SelectedValue != null)
{
    string selectedValue = listBox3.SelectedValue.ToString();
    if (!string.IsNullOrEmpty(selectedValue))
    {
        if (Int32.TryParse(selectedValue.Split(':')[0], NumberStyles.Integer, CultureInfo.CurrentCulture, out DBID))
        {
            // Process DBID
        }
        else
        {
            // Cannot convert to Int32
        }
    }
}
