    namespace SomeNameSpace
    {
        public partial class SourcePage: System.Web.UI.Page
        {
            public string ValueToPass
            {
                get
                {
                    if (Context.Items["ValueToPass"] == null)
                        Context.Items["ValueToPass"] = string.Empty;
                    return (string)Context.Items["ValueToPass"];
                }
                set
                {
                    Context.Items["ValueToPass"] = value;
                }
            }
    		........
    	}
    }
