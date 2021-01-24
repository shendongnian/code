if (DropDownList2.SelectedIndex == 0)
{
    DropDownList3.Items.Clear();
    DropDownList3.Items.Insert(0, new ListItem("A-1", ""));
}
if you will still want to use `selectedvalue` change the bindings of `new ListItem("A", "")` to `new ListItem("A", "");`
//populate first ddl with corret item and value
if(DropDownList1.SelectedValue =="1")
{
            DropDownList2.Items.Clear();
            DropDownList2.Items.Insert(0, new ListItem("A", ""));
            DropDownList2.Items.Insert(1, new ListItem("B", ""));
}
if (DropDownList2.SelectedValue == "A")
{
    DropDownList3.Items.Clear();
    DropDownList3.Items.Insert(0, new ListItem("A-1", ""));
}
`DropdownList.Items.Insert` implements `ddl.Items.Insert(indexPosition, new ListItem("displayItem", "value");`
so since you are searching for "0" in the `selectedvalue` which in your example does not exists since `new ListItem("A", "")` it will not execute the statement inside
