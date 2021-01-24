    //Name of Grid View : dataGridView1
    //Name of Column : CheckBoxColumn1
           private void button1_Click(object sender, EventArgs e)
            {
                // Place this code where you want to know the index
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[CheckBoxColumn1.Name].Value) == true) {
                        MessageBox.Show("Index " + i); // Show index in message box or add to a list for further processing 
                    }
                    
                }
                //
            }
