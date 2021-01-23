    private delegate void SetDGVValueDelegate();
    void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        dataGridView1.Invoke(new SetDGVValueDelegate(SetDGVValue));
    }
       
    private void SetDGVValue()
    {
        dataGridView1[0, 0].Value = "Will this work?";
    }
