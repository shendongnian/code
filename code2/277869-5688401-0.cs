    class CustomRichTextBox : RichTextBox
    {
        Timer tt = new Timer();
        public CustomRichTextBox()
        {
            tt.Tick += new EventHandler(tt_Tick);
            tt.Interval = 200;
        }
        protected override void OnTextChanged(EventArgs e)
        {
            tt.Stop();
            tt.Start();
        }
        void tt_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Hello world!");
        }
    }
