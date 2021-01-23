    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace Test
    {
        public partial class HelloFromCsharp : System.Web.UI.Page
        {
            public string clients;
            protected void Page_Load(object sender, EventArgs e)
            {
                clients = "Hello From C#";
            }
        }
    }
