      //pseudo code
        foreach (RadComboBoxItem item1 in radComboBoxTypes.Items)
        {
                  Label lblTypeId = item1.FindControl("lblTypeId") as Label;
                  CheckBox chkType = item1.FindControl("chkType") as CheckBox;
                  Label lblTypeNames = item1.FindControl("lblTypeNames") as Label;
                  bllMyClass objMyClass = new bllMyClass();
                  objMyClass.TextID = int.Parse(lblTextID.Text);
                  DataTable dtTypeId = new DataTable();
                  dtTypeId = objMyClass.GetTypesByTextID();
                  for (int i = 0; i < dtTypeId.Rows.Count; i++)
                  {
                        if (lblTypeId.Text == dtTypeId.Rows[i]["TypeId"].ToString())
                        {
                           chkType.Checked = true;
                           checkedTextType += checkedTextType==string.Empty?lblTypeNames.Text：", " + lblTypeNames.Text ;                                  
                        }
                  } 
         }
