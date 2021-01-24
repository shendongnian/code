                SqlConnection con = new SqlConnection("***COnString**");
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT SUM (Total_Hours_Day) FROM Sign_In_Out_Table, User_Table WHERE User_Table.FirstName = '" + Search_Username_Alerts_Admin_txtbox.Text + "' AND Sign_In_Out_Table.eb_number = User_Table.eb_number AND Date between GETDATE()-14 and GETDATE()", con);
                string TotalHoursFortnight = (comm.ExecuteScalar()).ToString();
                con.Close();
                decimal sum = 0;
                decimal temp;
                if(!decimal.TryParse(TotalHoursFortnight, out temp)) 
                { 
               
                    MessageBox.Show("No Data Exists");
                }
                else
                {
                    sum += temp;
                    MessageBox.Show(Search_Username_Alerts_Admin_txtbox.Text + ":" + Environment.NewLine + " Hours Worked = " + TotalHoursFortnight, ("Working Info Admin"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
