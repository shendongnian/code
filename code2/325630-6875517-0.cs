    public void Run()
    {
        foreach(var box in _boxes)
        {
           try { box.Run(); }
           catch(Exception ex){ /* handle exception */ }
        }
     }
