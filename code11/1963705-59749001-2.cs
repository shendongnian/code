 c#
private void Delete_Click(object sender, System.EventArgs e)
{
    if (gvModelsToDelete.SelectedRows.Count > 0)
    {
        modelName = "";
        foreach (DataGridViewRow row in gvModelsToDelete.SelectedRows)
        {
            if (string.IsNullOrEmpty(modelName)
            {
                modelName = row.Cells["MODEL_NAME"].Value.ToString();
            }
            else
            {
                modelName+= "," + row.Cells["MODEL_NAME"].Value.ToString();
            }
        }
    }
}
If you want to use LINQ and have something a little more terse, you can do this:
 c#
private void Delete_Click(object sender, System.EventArgs e)
{
    if (gvModelsToDelete.SelectedRows.Count > 0)
    {
        modelName = String.Join(",", 
            from row in gvModelsToDelete.SelectedRowsRows.Cast<DataGridViewRow>
            select row.Cells["MODEL_NAME"].Value.ToString();
        }
    }
}
