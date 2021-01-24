void UpdateInternal0(int employeeId)
{
    try
    {
        using (SqlConnection con = new SqlConnection(Properties.Settings.Default.adminConnectionString))
        {
            con.Open();
            foreach (DataRowView drv in InternalGrid0.SelectedItems)
            {
                DataRow row = drv.Row;
                bool isSelected = Convert.ToBoolean(drv.Row[0]);
                if (isSelected)
                {
                    string sqlString = "INSERT INTO ChecklistTransitionTable (RelatedEmployeeID, RelatedDocIdx) VALUES (@EmpID, @DOC_Number)";
                    using (SqlCommand cmd = new SqlCommand(sqlString, con))
                    {
                        for (int i = 0; i < InternalGrid0.Columns.Count; i++)
                        {
                            int DocIdx = 0;
                            try { 
                                 DocIdx = (int)drv.Row[i];
                            } catch (InvalidCastException ice) {
                                 // You should handle this here...
                            }
                            cmd.Parameters.AddWithValue("@EmpID", employeeId);
                            cmd.Parameters.AddWithValue("@DOC_Number", DocIdx);
                            int result = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            Console.WriteLine("Test");
                            //Check Error
                            if (result < 0)
                            {
                                System.Windows.Forms.MessageBox.Show("Error inserting data into database!");
                            }
                        }
                    }
                }
            }
        }
        System.Windows.Forms.MessageBox.Show("Employee data successfully updated.");
    }
    catch (SqlException ex)
    {
        System.Windows.Forms.MessageBox.Show(string.Format("\nMessage ---\n{0}", ex.Message));
    }
}
private void BtnGridUpdate_Click(object sender, EventArgs e)
{
    int employeeID = Convert.ToInt32(EmpID.Text);
    UpdateInternal0(employeeID);
}
