    namespace Demos.StackOverflow.MasterPages
    {
        using System;
        // Here, we inherits from PageWithStatus, not from Page.
        public partial class DefaultPage : PageWithStatus
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            protected void DefaultButton_Click(object sender, EventArgs e)
            {
                this.ChangeStatus("Done!");
            }
        }
    }
