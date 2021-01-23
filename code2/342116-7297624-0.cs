    void DoSomething()
    {
        if (dataGridView1.InvokeRequired)
            dataGridView1.Invoke(new Action(DoSomethingImpl));
        else
            DoSomethingImpl();
    }
    
    void DoSomethingImpl()
    {
        dataGridView1[columnIndex1, rowIndex1].Value = "Access is free!";
        dataGridView1[columnIndex1, rowIndex1].Style.BackColor = Color.Red;
    
        dataGridView1.Rows[rowIndex1].Visible = false;
    }
