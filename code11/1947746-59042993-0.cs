    namespace YourConstants
    {
    	public enum eDeviceStatus
    	{
    		NotUsed = 0,
    		Fail1 = 1,
    		SomeOtherFail = 2,
    		IsReady = 3,
    		etc = 4
    	}
    
    	public enum eOtherSettings
    	{
    		NotSetYet = 0,
    		DeviceXMode1 = 1,
    		AnotherSetting = 5,
    		GapBeforeSomethingElse = 22,
    		AndSomeMore = 45
    	}
    
    	public static class MyConstants
    	{
    		public const string Msg1 = "This is a sample message never change";
    		public const string OtherMsg = "Some other message to never change";
    		public const int SomeNumber = 123;
    
    		public static string CanBeChanged = "Sample Start Message";
    		public static int CurrentStatus = 5;
    
    		public static eOtherSettings CurrentSetting = eOtherSettings.NotSetYet;
    	}
    }
