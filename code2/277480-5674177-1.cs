    void Main()
    {
	
         IEnumerable<B> myB= new List<B>();
         IEnumerable<A> myA = myB;
    }
    public interface A
    {
    }
    public class B :A
    {
    }
