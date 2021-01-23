    foreach (GridViewRow grRow in grdACH.Rows)
        {
            CheckBox chkItem = (CheckBox)grRow.FindControl("checkRec");
            if (chkItem.Checked)
            {
                strID = ((Label)grRow.FindControl("lblBankType")).Text.ToString();
             }
    }
