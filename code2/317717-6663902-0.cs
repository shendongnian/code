    List<string> primaryKeys = new List<string>();
    foreach(GridViewRow row in GridForResult.Rows)
    {
        CheckBox check = row.FindControl("chkSelected") as CheckBox;
        if(check.Checked)
        {
            primaryKeys.Add(GridForResult.DataKeys["{your primary key}"].Value.ToString());
        }
    }
