    // IParentControlUpdater.cs
    namespace AspNetUserControlDynamicEvent {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        interface IParentControlUpdater {
            event EventHandler<EventArgs> UpdateParent;
        }
    }
    // DynamicUserControl.ascx.cs
    namespace AspNetUserControlDynamicEvent {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        public partial class DynamicUserControl : System.Web.UI.UserControl, IParentControlUpdater {
            protected void Page_Load(object sender, EventArgs e) { }
            #region IParentControlUpdater Members
            public event EventHandler<EventArgs> UpdateParent;
            #endregion
        }
    }
    // Default.aspx.cs
    namespace AspNetUserControlDynamicEvent {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        public partial class _Default : System.Web.UI.Page {
            protected void Page_Load(object sender, EventArgs e) { }
            private void LoadMyUserControl(string controlName) {
                UserControl control = (UserControl)LoadControl(controlName);
                // Do some stuff 
 
                ((IParentControlUpdater)control).UpdateParent += new EventHandler<EventArgs>(control_UpdateParent);
            }
            private void control_UpdateParent(object sender, EventArgs e) {
                throw new NotImplementedException();
            }
        }
    }
