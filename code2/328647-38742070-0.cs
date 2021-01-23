     panel1.Controls.Add(dataGridView);
     dataGridView.Columns["ID"].Visible = false; 
     //works
     dataGridView.Columns["ID"].Visible = false; 
     panel1.Controls.Add(dataGridView);
     //fails miserably
