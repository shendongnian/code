            if (row["visit_Logout_DateTime"] != DBNull.Value || row["visit_DateTime"] == DBNull.Value)
            {
              if (cbStatus.Text != "Refusals" && cbStatus.Text != "Accepts" && row["visit_Logout_DateTime"] != DBNull.Value)
              {
                DateTime dtlogout = DateTime.Parse(row["visit_Logout_DateTime"].ToString());
                if (true)
                {
                  if (cbPeriod.Text == "Today")
                  {
                    newItem.lblTime.Text = dtlogout.ToString("HH:mm:ss");
                    newItem.BackColor = Color.Cyan;
                  }
                  else
                    newItem.lblTime.Text = dtlogout.ToString("yyyy'-'MM'-'dd'  -  'HH':'mm':'ss");               
                  newItem.lblName.Text = string.Format("{0} {1}", row["member_Firstname"].ToString(), row["member_Lastname"].ToString());
                  newItem.lblAlertMessage.Text = string.Format("{0} {1}", row["member_EntryMessage"].ToString(), row["visit_AlertMsg"].ToString());
                  newItem.lblName.Text = string.Format("{0} {1}", row["member_Firstname"].ToString(), row["member_Lastname"].ToString());
                  newItem.lblAlertMessage.Text = string.Format("{0} {1}", row["member_EntryMessage"].ToString(), row["visit_AlertMsg"].ToString());              
                  newItem.tbHiddenId.Text = row["member_Id"].ToString();
                  newItem.ID = Convert.ToInt32(row["member_Id"].ToString());
                }
              }
              
            }
            else if (row["visit_Logout_DateTime"] == DBNull.Value || row["visit_DateTime"] != DBNull.Value)
            {
              DateTime dtTemp = DateTime.Parse(row["visit_DateTime"].ToString());
              newItem.lblTime.Text = dtTemp.ToString(cbPeriod.Text == "Today" ? "HH':'mm':'ss" : "yyyy'-'MM'-'dd'  -  'HH':'mm':'ss");
              newItem.lblName.Text = string.Format("{0} {1}", row["member_Firstname"].ToString(), row["member_Lastname"].ToString());
              newItem.lblAlertMessage.Text = string.Format("{0} {1}", row["member_EntryMessage"].ToString(), row["visit_AlertMsg"].ToString());
           
              newItem.tbHiddenId.Text = row["member_Id"].ToString();
              newItem.ID = Convert.ToInt32(row["member_Id"].ToString());
            }           
