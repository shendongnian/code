                if (rdr.Read())
                {
                    MessageBox.Show("Group Name taken, please try another name", "Error in Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    membernumber1.ReadOnly = true;
                    rdr.Close();
                }
                else
                {
                    rdr.Close();
                    sql = "INSERT INTO GroupNameNS VALUES ('" + Groupnametxt.Text.Trim() + "')";
                    membernumber1.ReadOnly = false;
                    cmd = new OleDbCommand(sql, db);
                    cmd.ExecuteNonQuery();
                }
