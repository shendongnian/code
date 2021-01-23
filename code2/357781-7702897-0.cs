    private void TelephoneDirectory_Load(object sender, EventArgs e)
    {
        dataGridView1.Visible = false;
        LoadImage();
        ThreadPool.QueueUserWorkItem(new WaitCallback(o => LoadData()));
    }
    void LoadData()
    {
        ...Do loading
        if (dataGridView1.InvokeRequired)
        {
            //Invoke only the ui-interaction code
            dataGridView1.Invoke(new MethodInvoker(this.LoadDataComplete));
        }
         
    }
    
