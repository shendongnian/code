    // DynamicUserControlBase.ascx.cs
    namespace AspNetUserControlDynamicEvent {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        public partial class DynamicUserControlBase : System.Web.UI.UserControl {
            protected void Page_Load(object sender, EventArgs e) { }
            // Base event
            public event System.EventHandler<System.EventArgs> UpdateParent;
        }
    }
