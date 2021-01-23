    foreach (GridViewRows gdrv in GridView1.Rows)
        {
            CheckBox chkUpdate = (CheckBox)
      gdrv.FindControl("chkSelect");
            if (chkUpdate != null)
            {
                if (chkUpdate.Checked)
                {
                    string strID = gdrv.Cells[1].Text;
                    SqlCommand cmd;
                    string str1 = "update app1 set p_id=0 where p_id='" + strID + "'";
                    cmd = new SqlCommand(str1, con);
                    con.open();
                    cmd .ExecuteNonQuery ();
                    con.close();
                }
            }
        }
