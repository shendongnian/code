        CheckBox chkDelete = (CheckBox)GridView1.Rows[i].FindControl("chkSelect");
        if (chkDelete != null)
        {
            if (chkDelete.Checked)
            {
                strID = GridView1.Rows[i].Cells[1].Text;
                idCollection.Add(strID);
            }
        }
    }
