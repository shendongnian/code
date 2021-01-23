    using System;
    using System.Windows.Forms;
    using SimplePluginShared;
    namespace SimplePluginExample
    {
        public partial class MyForm : PluginBase
        {
            private String _status = "Unspecified";
            public MyForm()
            {
                InitializeComponent();
            }
            public override string GetStatus()
            {
                return _status;
            }
            private void btnGive_Click(Object sender, EventArgs e)
            {
                _status = "Give Him The Stick.";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            private void btnDontGive_Click(object sender, EventArgs e)
            {
                _status = "Don't Give Him The Stick!";
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
