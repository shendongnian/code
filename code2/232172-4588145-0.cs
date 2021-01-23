    public interface IResetable
    {
        void Rest();
    }
    
    public class ClassA : IResetable
    {
        bool Enable = true;
        public void Reset()
        {
          Enable = false;
        }
    }
    
    void Manipulate(IResetable obj){
        obj.Reset();
    }
     
