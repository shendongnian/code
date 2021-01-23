	using System;
	using System.Reflection;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	namespace TestProject.UserControls
	{
		public partial class ucA : UserControl
		{
			public int Key;
			public LinkButton LbDetails
			{
				get { return this.LinkButton1; }
				set { LinkButton1 = value; }
			}
			protected void Page_Load(object sender, EventArgs e)
			{
				Page.GetType().InvokeMember("Partial_Postback", BindingFlags.InvokeMethod, null, Page, new object[] { this });
			}
		}
	}
