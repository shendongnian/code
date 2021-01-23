    using System;
    using System.Configuration;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace Web
    {
    	public class SpecialLabel : Label
    	{	
    		protected override void OnLoad (EventArgs e)
    		{
    			base.OnLoad (e);
    			
    			//get value from appsettings
    			if(!string.IsNullOrEmpty(this.ID)) {
    				Configuration rootWebConfig1 = WebConfigurationManager.OpenWebConfiguration(null);
    				if (rootWebConfig1.AppSettings.Settings.Count > 0)
    				{
    					KeyValueConfigurationElement customSetting = rootWebConfig1.AppSettings.Settings[this.ID];
    					if (customSetting != null)
    						this.Text = customSetting.Value;
    				}
    			}
    		}
    	
    	}
    }
