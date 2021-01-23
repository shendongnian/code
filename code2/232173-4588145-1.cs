    public class BaseResetClass 
    {
        internal bool Enable = true;
        public void Reset()
        {
          Enable = false;
        }
    }
    
    public class ClassA : BaseResetClass 
    {
    
    }
    public class ClassB : BaseResetClass 
    {
    
    }
    
    
    var ca = new ClassA();
    ca.Reset();
    
    var ca2 = new ClassB();
    ca2.Reset();
