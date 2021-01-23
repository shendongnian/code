    [ServiceBehavior]
    public class Foo : IFoo
    {
    	static ScriptEngine engine = Python.CreateEngine();
    	static Dictionary<string, ScriptHost> ScriptCache = new Dictionary<string, ScriptHost>();
    	static object _dictionaryLock = new object();
    
    	static void AddToCache(string edit, ScriptHost host)
    	{
    		lock (_dictionaryLock)
    		{
    			if (!ScriptCache.ContainsKey(edit))
    			{
    				ScriptCache.Add(edit, host);
    			}
    		}
    	}
    
    	...
    }
