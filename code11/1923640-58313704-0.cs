c#
protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
{
    if (e.Item.IsInEditMode)
    {
        GridEditableItem edititem = e.Item as GridEditableItem;
        DropDownList rddl = new DropDownList();
        edititem["AssetTypeName"].Controls[0].Visible = false;
        rddl.ID = "ddlAssetTypeName";
        rddl.AutoPostBack = false;
        rddl.DataSource = Enumerable.Range(1, 3).Select(x => "Item" + x).ToList();
        rddl.DataBind();
        edititem["AssetTypeName"].Controls.Add(rddl);
    }
}
protected void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
{
    GridEditableItem editedItem = e.Item as GridEditableItem;
    DropDownList ddl = editedItem["AssetTypeName"].FindControl("ddlAssetTypeName") as DropDownList;
    string selectedValue = ddl.SelectedValue;
}
