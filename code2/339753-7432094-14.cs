    	public static class MementoExtensions
    	{
    		public static T IsolateMemento<T>(
    			this T originator,
    			Func<T, IDisposable> generateMemento,
    			Func<T, T> map)
    		{
    			using (generateMemento(originator))
    				return map(originator);
    		}
    	}
