    conn.con.Open();
    foreach (DataGridViewRow data in dataGridView1.Rows)
    {
        if (bool.Parse(data.Cells[0].Value.ToString()))
        {            
            if (DialogResult.Yes == MessageBox.Show("Do you want to Delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                OleDbCommand command = new OleDbCommand("Delete FROM tblTransaction WHERE ID='?'", conn.con);
                command.Parameters.AddWithValue("@ID", data.Cells[1].Value.ToString());
                command.ExecuteNonQuery();
                MessageBox.Show("Data Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (DialogResult == DialogResult.No)
            {
              //nothing to do
            }            
        }
    }
    conn.con.Close();
