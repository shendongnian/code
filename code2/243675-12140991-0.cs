    var daysCount = DateTime.DaysInMonth(DateTime.Now.Year, 1);
    
    for (int i = 0; i <= daysCount; i++)
            {
              i = dataGridView1.Rows.Add(new DataGridViewRow());
    
                            
                            dataGridView1.Rows[i].Cells["YourNameCell"].Value = i.ToString();
    
           }
