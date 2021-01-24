C#
    
    public interface IA
    {
    } 
    public class A1 : IA
    {
        public int dataA1 { get; set; }
    }
    public class A2 : IA
    {
        public int dataA2 { get; set; }
    }
    public void GetData<IA>()
    {
        
    }
    GetData<A1>();
    GetData<A2>();
