    private delegate void SetDGVValueDelegate(BindingList<Something> items);
    void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        // Some call to your data access infrastructure that returns the list of itmes
        // or in your case a datatable goes here, in my code I just create it in memory.
        BindingList<Something> items = new BindingList<Something>();
        items.Add(new Something() { Name = "does" });
        items.Add(new Something() { Name = "this" });
        items.Add(new Something() { Name = "work?" });
        SetDGVValue(BindingList<Something> items)
    }
       
    private void SetDGVValue(BindingList<Something> items)
    {
        if (dataGridView1.InvokeRequired)
        {
            dataGridView1.Invoke(new SetDGVValueDelegate(SetDGVValue), items);
        }
        else
        {
            dataGridView1.DataSource = items;
        }
    }
