    private void button1_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("Name", typeof(string));
    
        dt.Rows.Add(1, "A");
        dt.Rows.Add(2, "B");
        dt.Rows.Add(3, "C");
    
        comboBox1.DataSource = dt;
        comboBox1.DisplayMember = "Name";
        comboBox1.ValueMember = "ID";
                
        // use SelectedValue to select the item with ID == 2
        comboBox1.SelectedValue = 2;
    
        // use FindStringExact() to find the index of text displayed in the item
        comboBox1.SelectedIndex = comboBox1.FindStringExact("C");
    }
