    using System;
    using System.Threading;
    using System.Windows.Forms;
    public partial class MyForm: Form
    {
        public MyForm()
        {
            InitializeComponent();
        }
        private void Button1Click(object sender, EventArgs e)
        {
            var t = new Thread(() => Application.Run(new MyForm()));
            t.Start();
        }
    }
