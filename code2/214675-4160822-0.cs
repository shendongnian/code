    public static class ConstantManager {
	private static Hashtable _consts = new Hashtable();    
	private static const keyName = "Name 1";
	public static void ConstantManager()
	{
		_consts[keyName] = ...;
	}
	public static Hashtable GetConstants()
	{
		var _copy = new Hashtable(_consts);
		return _copy;
	}
    }
    public OtherClass{
	public void Method()
	{
		var consts = ConstantManager.GetConstants();
		var a = consts[ConstantManager.keyName];
	}
    }
