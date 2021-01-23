    public interface IValueType<T> 
    {    
        T Value{ get; set; } 
    } 
    public abstract class ValueType<T,K> : 
        IValueType<T> where K : ValueType<T,K>,new()
    {     
        public abstract T Value { get; set; }     
        public static explicit operator T(ValueType<T,K> vt) 
        {         
            if(vt == null)            
                return default(T);         
            return vt.Value;     
        }      
        public static implicit operator ValueType<T,K>(T val) 
        {         
            K k = new K();
            k.Value = val;
            return k;    
        } 
    } 
    public class Test : ValueType<int,Test>
    {
        public override int Value {get;set;}
    }
