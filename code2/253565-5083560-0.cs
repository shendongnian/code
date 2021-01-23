    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace SATest
    {
    	[DefaultProperty("ConversionCode")]
    	[ToolboxData("<{0}:AdwordConversion runat=server></{0}:AdwordConversion>")]
    	public class AdwordConversion : Control
    	{
    		private const string _conversionCodeKey = "cc";
    		private const string _includeScriptKey  = "ic";
    
    		[Category("Behavior")]
    		[DefaultValue("")]
    		public string ConversionCode
    		{
    			get { return (String)(ViewState[_conversionCodeKey] ?? "" ); }
    			set { ViewState[_conversionCodeKey] = value; }
    		}
    
    		[Category("Behavior")]
    		[DefaultValue(false)]
    		public bool IncludeScript
    		{
    			get { return (bool)(ViewState[_includeScriptKey] ?? false ); }
    			set { ViewState[_includeScriptKey] = value; }
    		}
    
    
    		protected override void Render(HtmlTextWriter writer)
    		{
    			if ( !IncludeScript ) { return; }
    
    			string js = "<script type=\"text/javascript\">...Insert conversion code here: var code = " + ConversionCode + ";</script>";
    
    			writer.Write( js );
    		}
    
    		protected override void OnInit(EventArgs e)
    		{
    			base.OnInit(e);
    
    			if ( Page.Items.Contains( typeof(AdwordConversion) ) ) 
    			{
    				throw new ApplicationException( "There can be only one AdwordConversion control defined on a page.  Use AdwordConversionProxy." );
    			}
    			
    			Page.Items[typeof(AdwordConversion)] = this;
    		}
    	}
    }
