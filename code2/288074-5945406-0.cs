    private void AddClick(object sender, EventArgs e)
    {
        // Set the DataSource property.          
        listBox2.ValueMember = "Code";
        listBox2.DisplayMember = "Description";    
        listBox2.Items.Add(listBox1.SelectedItem); 
    }    
