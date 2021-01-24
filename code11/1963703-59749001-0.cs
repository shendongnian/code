 c#
private void Delete_Click(object sender, System.EventArgs e)
{
    if (gvModelsToDelete.SelectedRows.Count > 0)
    {
        modelName = "";
        foreach (var row in gvModelsToDelete.SelectedRows)
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
