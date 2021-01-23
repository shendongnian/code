    bool found = false;
    for (int i = 0; i < dt.Rows.Count; i++)
    {
      if (dt.Rows[i]["Code"] == code)
      {
        found = true;
        break;
      }
    }
    if (found)
    {
      Label lblLang = (Label)(((e.Item as GridItem).FindControl("lblLang") as Label));
      lblLang.Visible = true;
    }
    else
    {
       objTelerikLang.InsertUpdateLang(objTelerikLang);
       RadGrid.Rebind();
       RadGrid.MasterTableView.IsItemInserted = false;
       RadGrid.MasterTableView.Rebind();
     }
