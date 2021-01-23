    private void button1_Click(object sender, EventArgs e)
        {
            MyApplication myApp = new MyApplication();
            myApp.OnLogging += new MyApplication.OnLoggingEventHandler(MyApplication_OnLogging);
            myApp.BusinessMethod();
        }
        
