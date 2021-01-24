c#
Set the `Enabled` everytime for every element. This way you don't have to bother about the status before changing.. And it's shorter..
protected void DropDownList1_ItemChanged(object sender, EventArgs e)
{
    DropDownList2.Items.Cast<ListItem>()
        .ToList()
        .ForEach(x => x.Enabled = (DropDownList1.SelectedItem.Value == x.Value.Substring(0, 2)));
}
