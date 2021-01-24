    foreach (DataRowView drv in InternalGrid0.SelectedItems)
    {
        DataRow row = drv.Row;
        bool isSelected = Convert.ToBoolean(drv.Row[0]);
        if (isSelected)
        {
            string sqlString = "INSERT INTO ChecklistTransitionTable (RelatedEmployeeID, RelatedDocIdx) VALUES (@EmpID, @DOC_Number)";
            using (SqlCommand cmd = new SqlCommand(sqlString, con))
            {
                int DocIdx = Convert.ToInt32(row["DOC_Number"]);
                cmd.Parameters.AddWithValue("@EmpID", employeeId);
                cmd.Parameters.AddWithValue("@DOC_Number", DocIdx);
                int result = cmd.ExecuteNonQuery();
                if (result < 0)
                {
                    System.Windows.Forms.MessageBox.Show("Error inserting data into database!");
                }
            }
        }
    }
