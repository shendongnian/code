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
    	[ToolboxData("<{0}:AdwordConversionProxy runat=server></{0}:AdwordConversionProxy>")]
    	public class AdwordConversionProxy : Control
    	{
    		private string _conversionCode;
    		private bool?  _includeScript;
    
    		public string ConversionCode
    		{
    			get { return _conversionCode; }
    			set { _conversionCode = value; }
    		}
    
    		public bool IncludeScript
    		{
    			get { return ( _includeScript.HasValue ) ? _includeScript.Value : false; }
    			set { _includeScript = value; }
    		}
    
    
    		protected override void Render(HtmlTextWriter writer)
    		{
    		}
    
    		protected override void OnPreRender(EventArgs e)
    		{
    			base.OnPreRender(e);
    
    			AdwordConversion current = Page.Items[typeof(AdwordConversion)] as AdwordConversion;
    
    			if ( current == null )
    			{
    				throw new ApplicationException( "AdwordConversionProxy requires that an AdwordConversion control already exist on a page." );
    			}
    
    			if ( _conversionCode != null )
    			{
    				current.ConversionCode = _conversionCode;
    			}
    
    			if ( _includeScript.HasValue )
    			{
    				current.IncludeScript = _includeScript.Value;
    			}
    		}
    	}
    }
