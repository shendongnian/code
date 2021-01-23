    using Microsoft.Win32;
    RegistryKey key = 
       Registry.LocalMachine.CreateSubKey ("The Right Value");
    private void InitializeTheKey()
    {
  
        this.MaxIndex = 0; // Or any other value ..
    }
    public Int32 MaxIndex 
    { 
       get{ return  key.GetValue("MaxIndex"); }
       set{  key.SetValue ("MaxIndex", value); } 
    }
    public Int32 GetNewIndex()
    {
         
        this.MaxIndex += 1;
        return this.MaxIndex;
        
    }
