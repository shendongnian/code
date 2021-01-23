    public static void Main()
    {
    	Base<int> foo = new Derived();
    }
    
    class Base<T>
    {
    	public T data;
    }
    
    class Derived:Base<int>
    {
    }
