    public class MyBaseForm : Form
    {
        public MyBaseForm()
        {
            this.Load += MyBaseForm_Load;
        }
        private void MyBaseForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("MyBaseForm_Load");
        }
    }
    public class MyDerivedForm : MyBaseForm
    {
        public MyDerivedForm()
        {
            var eventInfo = this.GetType().GetEvent("Load",
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance);
            var delegateType = eventInfo.EventHandlerType;
            eventInfo.RemoveEventHandler(this, 
                Delegate.CreateDelegate(delegateType, this, "MyBaseForm_Load", false, true));
            this.Load += MyDerivedForm_Load;
        }
        private void MyDerivedForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("MyDerivedForm_Load");
        }
    }
