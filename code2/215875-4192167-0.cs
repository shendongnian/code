    private void MyThreadLoop()
    {
       try 
       {
            while (someCondition)
            {
                // do a lengthy operation
            }
       }
       catch (Exception ex) 
       {
            Log.Error("Something bad happened: ", ex);
       }
    }
    public void Start() 
    {  
        Thread t = new Thread(MyThreadLoop); 
        t.Start()
    }
