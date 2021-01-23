    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    
    namespace Mri.Controls
    {
    	public class ScriptLoader : Control
    	{
    		protected List<string> ScriptUrls;
    
    		public ScriptLoader()
    		{
    			ScriptUrls = new List<string>();
    		}
    
    		// Have to add libraries here because cannot access the Page object from the Constructor
    		protected override void OnInit(EventArgs e)
    		{
    			base.OnInit(e);
    
    			AddScriptKey("Mri.Controls.Resources.Scripts.Libraries.jQuery.js");
    		}
    
    		public void AddScriptKey(string key)
    		{
    			//	Using the assembly location, find the WebResourceUrl
    			var webResourceUrl = Page.ClientScript.GetWebResourceUrl(typeof(ScriptLoader), key);
    			AddScriptUrl(webResourceUrl);
    		}
    
    		public void AddScriptUrl(string url)
    		{
    			//	Check to see if script already exists
    			if (!ScriptUrls.Any(s => s.Equals(url)))
    				ScriptUrls.Add(url);
    		}
    
    		protected override void Render(HtmlTextWriter writer)
    		{    
    			//	Render the script tags
    			foreach (var scriptUrl in ScriptUrls)
    			{
    				writer.Write(string.Format("\n<script type=\"text/javascript\" src=\"{0}\"></script>", scriptUrl));
    			}
    		}
    	}
    }
