    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        var checkcell = new DataGridViewCheckBoxCell();
        checkcell.FalseValue = false;
        checkcell.TrueValue = true;
        dataGridView1[0, 0] = checkcell; //Adding the checkbox
    
        if (((bool)((DataGridViewCheckBoxCell)dataGridView1[0, 0]).Value) == true)
        {
            //Stuff to do if the checkbox is checked
        }
    }
