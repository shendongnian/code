    public partial class Form1 : Form
        {
            SynchronizationContext context;
            public Form1()
            {
                InitializeComponent();
                context = SynchronizationContext.Current;
            }
            // Sets the text of scan history in the ui
            private void SetScanHistory(string text)
            {
                CallFunc(text);
            }
            private void CallFunc(string TextValue)
            {            
                context.Post(new SendOrPostCallback(
                delegate
                {
                    textBox1.Text += TextValue + Environment.NewLine;
                }), TextValue);
            }
        }
