if (DropDownList2.SelectedIndex == 0)
{
    DropDownList3.Items.Clear();
    DropDownList3.Items.Insert(0, new ListItem("A-1", ""));
}
if you will still want to use `selectedvalue` change it to `A`
//populate first ddl with corret item and value
if(DropDownList1.SelectedValue =="1")
{
            DropDownList2.Items.Clear();
            DropDownList2.Items.Insert(0, new ListItem("A", "0"));
            DropDownList2.Items.Insert(1, new ListItem("B", "1"));
}
if (DropDownList2.SelectedValue == "0")
{
    DropDownList3.Items.Clear();
    DropDownList3.Items.Insert(0, new ListItem("A-1", "0"));
}
