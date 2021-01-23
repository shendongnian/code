    private void SavePageState(GridView gv)
    {
        ArrayList categoryIDList = new ArrayList();
        Int32 index = -1;
        foreach (GridViewRow row in gv.Rows)
        {
            HiddenField hfStudentUnitID = (HiddenField)row.FindControl("hfStudentUnitID");
            if (hfStudentUnitID != null)
            {
                if (hfStudentUnitID.Value.Length > 0)
                {
                    index = Convert.ToInt32(hfStudentUnitID.Value.ToString()); //gv.DataKeys[row.RowIndex]["StudentUnitID"];
                    bool result = ((CheckBox)row.FindControl("cbSEND")).Checked;
    
                    // Check in the Session
                    if (Session["CHECKED_ITEMS"] != null)
                        categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
                    if (result)
                    {
                        if (!categoryIDList.Contains(index))
                            categoryIDList.Add(index);
                    }
                    else
                        categoryIDList.Remove(index);
                }
            }
        }
        if (categoryIDList != null && categoryIDList.Count > 0)
            Session["CHECKED_ITEMS"] = categoryIDList;
    }
