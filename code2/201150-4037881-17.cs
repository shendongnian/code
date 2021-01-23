    using System;
    using System.Web.UI;
    
    namespace StackOverflow.Bounties.Web.UI
    {
        public partial class TestTracePage : TraceablePage
        {
            protected void enableTrace_CheckedChanged(object sender, EventArgs e)
            {
                EnableTraceOutput = enableTrace.Checked;
            }
        }
    }
