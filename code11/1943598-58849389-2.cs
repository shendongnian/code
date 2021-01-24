    private void UpdateUI()
    {
        loaddata();
        chart1.Update();
        chart1.Refresh();
    }
    
    private void loaddata()
    {
        //pull datas from datagrid to chart
    }
    
    private void InitializeTimer()  
    {  
       // Run this procedure in an appropriate event (every 10 seconds).  
       timer1.Interval = 10000;  // in miliseconds
       timer1.Enabled = true;  
       // Hook up timer's tick event handler.  
       this.timer1.Tick += new System.EventHandler(this.timer1_Tick);  
    }  
      
    private void timer1_Tick(object sender, System.EventArgs e)     
    {  
       UpdateUI();
    }  
