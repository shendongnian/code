    private delegate void SetDGVValueDelegate(DataTable table);
    private void button1_Click(object sender, EventArgs e)
    {
        new Thread(() =>    {        
            DataTable table = Finish(txtTest.Text);
            SetDGVValue(table);
        }).Start();
    }
    private void SetDGVValue(DataTable table) 
    { 
        if (dataGridView1.InvokeRequired) 
        { 
            dataGridView1.Invoke(new SetDGVValueDelegate(SetDGVValue), table); 
        } 
        else 
        { 
            dataGridView1.DataSource = table; 
        } 
    }
