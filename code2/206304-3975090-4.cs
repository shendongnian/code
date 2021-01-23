    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    public static class EventUtils {
        public static void SafeInvoke(this PropertyChangedEventHandler handler, object sender, string propertyName) {
            if(handler != null) handler(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
    class MyObject : INotifyPropertyChanged
    {
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; PropertyChanged.SafeInvoke(this,"Name"); } }
        private MyInner _Inner;
        public MyInner Inner { get { return _Inner; } set { _Inner = value; PropertyChanged.SafeInvoke(this,"Inner"); } }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    
    class MyInner : INotifyPropertyChanged
    {
        private string _SomeValue;
        public string SomeValue { get { return _SomeValue; } set { _SomeValue = value; PropertyChanged.SafeInvoke(this, "SomeValue"); } }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    static class Program
    {
        [STAThread]
        public static void Main() {
            var myObject = new MyObject();
            myObject.Name = "old name";
            // optionally start with a default
            //myObject.Inner = new MyInner();
            //myObject.Inner.SomeValue = "old inner value";
    
            Application.EnableVisualStyles();
            using (Form form = new Form())
            using (TextBox txtName = new TextBox())
            using (TextBox txtSomeValue = new TextBox())
            using (Button btnInit = new Button())
            {
                var outer = new BindingSource { DataSource = myObject };
                var inner = new BindingSource(outer, "Inner");
                txtName.DataBindings.Add("Text", outer, "Name");
                txtSomeValue.DataBindings.Add("Text", inner, "SomeValue");
                btnInit.Text = "all change!";
                btnInit.Click += delegate
                {
                    myObject.Name = "new name";
                    var newInner = new MyInner();
                    newInner.SomeValue = "new inner value";
                    myObject.Inner = newInner;
                };
                txtName.Dock = txtSomeValue.Dock = btnInit.Dock = DockStyle.Top;
                form.Controls.AddRange(new Control[] { btnInit, txtSomeValue, txtName });
                Application.Run(form);
            }
        }
    
    }
