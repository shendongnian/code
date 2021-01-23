    private void TelephoneDirectory_Load(object sender, EventArgs e)
    {
        dataGridView1.Visible = false;
        LoadImage();
        ThreadPool.QueueUserWorkItem(new WaitCallback(o => LoadData()));
    }
    void LoadData()
    {
        //...Do loading
        //but don't add rows to dataGridView
      
        if (dataGridView1.InvokeRequired)
        {
            //Invoke only the ui-interaction code
            dataGridView1.Invoke(new MethodInvoker(this.LoadDataComplete));
        }
         
    }
    void LoadDataComplete() 
    {
        foreach (SearchResult result in res)
        {
            //DO ALL MY STUFF
            //If do all my stuff is compute intensive and doesn't require UI,
            //put it before Invoke() (like here)
            dataGridView1.Rows.Add(row);
        }
        //Rest of code
     }
    
