    namespace SomeNameSpace
    {
        public partial class SourcePage: System.Web.UI.Page
        {
    		protected void Page_Load(object sender, EventArgs e)
            {
                var value = this.Context.Items["ValueToPass"];
    		}
    	}
    }
