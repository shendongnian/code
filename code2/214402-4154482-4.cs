    namespace Demos.StackOverflow.MasterPages
    {
        using System;
        using System.Web.UI;
        // Here's my SiteMaster class.
        public partial class SiteMaster : MasterPage
        {
            public string StatusText { get; set; }
            protected void Page_Load(object sender, EventArgs e)
            {
            }
        }
    }
