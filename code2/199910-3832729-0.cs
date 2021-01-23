    namespace MyControls
    {
    	public class MyControl : System.Web.UI.WebControls.WebControl
    	{
    		System.Web.UI.WebControls.Repeater FirstRepeater = new System.Web.UI.WebControls.Repeater();
    		System.Web.UI.WebControls.Repeater SecondRepeater = new System.Web.UI.WebControls.Repeater();
    
    		[System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty)]
    		public System.Web.UI.ITemplate FirstTemplate
    		{
    			get
    			{
    				return FirstRepeater.ItemTemplate;
    			}
    			set
    			{
    				FirstRepeater.ItemTemplate = value;
    			}
    		}
    
    		[System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty)]
    		public System.Web.UI.ITemplate SecondTemplate
    		{
    			get
    			{
    				return SecondRepeater.ItemTemplate;
    			}
    			set
    			{
    				SecondRepeater.ItemTemplate = value;
    			}
    		}
    
    		protected override void CreateChildControls()
    		{
    			base.Controls.Add(FirstRepeater);
    			object[] FirstDataSource = {
    				new { x = "1" },
    				new { x = "2" },
    				new { x = "3" },
    				new { x = "4" }
    			};
    			FirstRepeater.DataSource = FirstDataSource;
    			FirstRepeater.DataBind();
    
    			base.Controls.Add(SecondRepeater);
    			object[] SecondDataSource = {
    				new { y = "a" },
    				new { y = "b" },
    				new { y = "c" },
    				new { y = "d" }
    			};
    			SecondRepeater.DataSource = SecondDataSource;
    			SecondRepeater.DataBind();
    
    			base.CreateChildControls();
    		}
    	}
    }
