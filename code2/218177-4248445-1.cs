    public partial class WebUserControl1 : System.Web.UI.UserControl {
        public event EventHandler MyMethodIsFinished;
       
        // ...
        protected void MyMethod {
            // ...
            if (MyMethodIsFinished != null)
                MyMethodIsFinished(this, EventArgs.Empty);
        }
    }
