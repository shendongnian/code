    public class Form1 : Form
    {
        private UserControl1 myControl;
        public Form1()
        {
            myControl = new UserControl1();
            Controls.Add(myControl);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            myControl.InvokeOnKeyDown(e);
        }
    }
