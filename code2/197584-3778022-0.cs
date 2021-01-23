     protected void ChkAll_CheckedChanged(object sender, EventArgs e)
            {
                try
                {
                    CheckBox chk;
                    foreach (RepeaterItem rowItem in this.rptFriendsRecord.Items)
                    {
                        chk = (CheckBox)rowItem.FindControl("cbFriend");
                        chk.Checked = ((CheckBox)sender).Checked;
                    }
                }
                catch { }
            }
