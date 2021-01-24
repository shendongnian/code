    public partial class MyUserControl : UserControl
    {
        public MyUserControl() { InitializeComponent(); }
        public EventHandler OKSelected;
        public EventHandler ProcessingFinished;
        public string Info { get; private set; }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var f = new Form()) {
                var button = new Button() { Text = "OK" };
                f.Controls.Add(button);
                button.DialogResult = DialogResult.OK;
                this.Disposed += (obj, args) => {
                    if (!(f.IsDisposed || f.Disposing)) {
                        f.Close(); f.Dispose();
                    }
                };
                if (f.ShowDialog() == DialogResult.OK) {
                    //If you need, raise the OKSelected event
                    //So you can handle it in the main form, for example to stop timer
                    OKSelected?.Invoke(this, EventArgs.Empty);
                    //
                    //Do whatever you need to do after user closed the dialog by OK
                    //
                    //If you need, raise the ProcessingFinished event
                    //So you can handle it in the main form, for example to start timer
                    //You can also set some properties to share information with main form
                    Info = "something";
                    ProcessingFinished?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
