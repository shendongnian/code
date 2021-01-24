    int connectedRowId = -1;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        value = Convert.ToInt32(textBox1.Text);
    
        if (value == 2)
        {
          string[] row1 = { "Value is 2" }; //column name is column1
          connectedRowId  = dataGridView1.Rows.Add(row1);
        }
    
       if (value == 0)
        {
          dataGridView1.Rows.RemoveAt(connectedRowId);
        }
    }
