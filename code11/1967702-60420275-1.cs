    using System;
    using System.Web.UI;
    using Creator.Foo;
    
    public partial class YOUR_PAGE_CLASS_HERE : Page {
        protected void Page_Init(object sender, EventArgs e) {
            CoolComponent c = new CoolComponent();
            c.ID = "CoolControl";
            Form.Controls.Add(c);
        }
    }
