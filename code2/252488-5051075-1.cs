     foreach (DataRow dr in dtResult.Rows)
     {
        string cWorkTypeID = dr["WorkTypeID"].ToString();
        for (var i = 0; i < chkboxListWorkTypes.Items.Count; i++)
        {
             if(chkboxListWorkTypes.Items[i].Value.Equals(cWorkTypeID))
             {
                chkboxListWorkTypes.Items[i].Selected = true;
                break;
             }
        }
     }
