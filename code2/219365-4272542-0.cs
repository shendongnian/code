    public interface IDataAdapter
    {
        void Save(BusinessProxy proxy);
    }
    public class BusinessProxy
    {
        public static DataAdapterRegistry Adapter = new DataAdapterRegistry();
        public bool Save()
        {
            Adapter.Save(this);
            return true;
        }
    }
    public class DataAdapterRegistry : IDataAdapter
    {
	    private Dictionary&lt;Type, IDataAdapter&gt; registry 
                                    = new Dictionary&lt;Type, IDataAdapter&gt;();
	
	    public void Register(Type type, IDataAdapter adapter)
	    {
		    registry[type] = adapter;
	    }
	
	    public void Save(BusinessProxy proxy)
	    {
	        IDataAdapter adapter;
                if (registry.TryGetValue(proxy.GetType(), out adapter))
                   adapter.Save(proxy);
                else
                   throw new NotSupportedException(proxy.GetType().FullName);		
	    }
    }
    class Customer : BusinessProxy
    {
    }
    class Order : BusinessProxy
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            BusinessProxy.Adapter.Register(typeof(Customer), new CustomerAdapter());
            BusinessProxy.Adapter.Register(typeof(Order), new OrderAdapter());
        }
    }
