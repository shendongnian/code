    public abstract class ProcessorBase 
    {   
      public int Register;
      public virtual int Inc()
      {
        Register = Add(1);     
        return Register;
      } 
      public abstract int Add(int i); 
    }
