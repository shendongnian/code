    private void HandleTextChanged(object sender, EventArgs e)
    {
        if(int.TryParse(textBox1.Text, out var number))
        {
            if(number == 2)
            {
                string[] newRow = { "Value is 2" };
                dataGridView1.Rows.Add(newRow);
            }
        }
    }
    
