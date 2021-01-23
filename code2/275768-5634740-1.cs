    public class TestEvent : Form
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            MyMethod();
        }
        private void MyMethod()
        {
            
            this.Invoke(new Action(() =>
                                       {
                                          //Here goes your code.
                                       }));
        }
    }
