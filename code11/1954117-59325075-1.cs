    	public class CustomList : List<string>
    	{ }
    	public class BaseService
    	{
    		public BaseService(IKeyValuePair<List<string>, string> p1)
    		{ }
    	}
    	public class DerivedService : BaseService
    	{
    		public DerivedService(IKeyValuePair<CustomList, string> p1) : base(p1)
    		{ }
    	}
        public interface IKeyValuePair<out TKey, out TValue>
        {
             TKey Key {get;}
             TValue Value {get;}
        }
