     int sum = 0;
     int ColumnIndex=1; //your column index 
     //Iterate through all the cells of Specified ColumnIndex in each row and get the sum 
     for (int i = 0; i < dataGridView1.Rows.Count; ++i)
     {
        sum += int.Parse(dataGridView1.Rows[i].Cells[ColumnIndex].Value.ToString());
     }
     //display sum 
     textBox1.Text = sum.ToString();
