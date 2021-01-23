    public partial class WebUserControl1 : System.Web.UI.UserControl {
        public event EventHandler MyMethodIsFinished;
       
        // ...
        protected void myMethod {
            // ...
            if (MyMethodIsFinished != null)
                MyMethodIsFinished(this, EventArgs.Empty);
        }
    }
