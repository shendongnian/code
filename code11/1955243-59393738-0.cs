public void ResetList(ListControl control, DataTable newData)
{
    control.Items.Clear();
    control.DataSource = newData;
    control.DataBind();
}
