    public interface IActualThing
    {
    }
    public interface ISomething 
    {    
        ISomething Clone(); 
    }  
    
    public abstract class Something: ISomething  
    {
        public abstract ISomething Clone();
        protected virtual void _SomethingNeededInternally()
        {
            throw new NotImplementedException(); 
        }
    }  
    
    public abstract class Something<T>: Something, ISomething where T: ISomething, new()
    {    
        public override ISomething Clone()    
        {
            return new T().Clone(); 
        } 
    }  
    
    public class ActualThing: Something<ActualThing>, IActualThing 
    {     
        public override ISomething Clone()      
        {
            throw new NotImplementedException(); 
        }
    } 
