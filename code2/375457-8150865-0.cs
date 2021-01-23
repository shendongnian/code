    void run()
    {
       for(int i = 0; i < 1000000; i++)
       {
    
       }
       Invoke(new MethodInvoker(delegate()
                                             {
                                                 label1.Text = "finished";
                                             }));
    }
