    public interface ICollect<T>
    {
    	void Collect(T obj);
    }
    
    public class Car : ICollect<Car>
    {
    	public void Collect(Car obj)
    	{
    	//Do stuff
    	}
    }
