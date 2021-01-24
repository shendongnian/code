    using System;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    public class MyControl : Control
    {
        IDesignerHost host;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            host = (IDesignerHost)Site.GetService(typeof(IDesignerHost));
            host.TransactionOpened += Host_TransactionOpened;
            host.TransactionClosed += Host_TransactionClosed;
        }
        bool resizing = false;
        private void Host_TransactionOpened(object sender, EventArgs e)
        {
            if (host?.TransactionDescription?.StartsWith("Resize") == true)
            {
                resizing = true;
                ((Control)host.RootComponent).Text = "Resize Started.";
            }
        }
        private void Host_TransactionClosed(object sender, DesignerTransactionCloseEventArgs e)
        {
            if (resizing)
            {
                resizing = false;
                ((Control)host.RootComponent).Text = "Resize ended.";
            }
        }
    }
