    using YourConstants;
    
    namespace YourCommonApp
    {
    	public class Whatever
    	{
    		public void SomeMethod()
    		{
    			switch(YourConstants.MyConstants.CurrentSetting)
    			{
    				case YourConstants.eOtherSettings.NotSetYet:
    					MessageBox.Show(YourConstants.MyConstants.Msg1);
    					break;
    
    				case YourConstants.eOtherSettings.DeviceXMode1:
    					MessageBox.Show(YourConstants.MyConstants.OtherMsg);
    					break;
    
    				default:
    					// change or do something on your single-instance main static class
    					YourConstants.MyConstants.CurrentSetting = YourConstants.eOtherSettings.AnotherSetting;
    					break;
    			}
    		}
    	}
    }
