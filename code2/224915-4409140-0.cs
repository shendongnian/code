    public Data
    {
       public event EventHandler OnSave
       public EventHandler OnLoad;
    
       private void Load()
       {
           if (OnLoad!=null) OnLoad();  
           //other operations
       }
       private void Save()
       {
           if (OnSave!=null) OnSave();  
           //other operations
       }
    }
