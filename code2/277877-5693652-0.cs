     foreach (GridViewRow rowitem in GridView1.Rows)
                {
                    CheckBox chkDelete = (CheckBox)rowitem.Cells[0].FindControl("chkSelect");
                    if (chkDelete != null)
                    {
                        if (chkDelete.Checked)
                        {
                            strID = rowitem.Cells[1].Text;
                            idCollection.Add(strID);
                        }
                    }
    
    
                }
