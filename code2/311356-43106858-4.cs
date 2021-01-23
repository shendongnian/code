    private void LoadPageState(GridView gv)
    {
        ArrayList categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
        if (categoryIDList != null && categoryIDList.Count > 0)
        {
            foreach (GridViewRow row in gv.Rows)
            {
                HiddenField hfStudentUnitID = (HiddenField)row.FindControl("hfStudentUnitID");
                if (hfStudentUnitID != null)
                {
                    if (hfStudentUnitID.Value.Length > 0)
                    {
                        Int32 index = Convert.ToInt32(hfStudentUnitID.Value.ToString()); //gv.DataKeys[row.RowIndex]["StudentUnitID"];
                        if (categoryIDList.Contains(index))
                        {
                            CheckBox myCheckBox = (CheckBox)row.FindControl("cbSEND");
                            myCheckBox.Checked = true;
                        }
                    }
                }
            }
        }
    }
