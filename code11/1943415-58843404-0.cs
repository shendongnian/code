    class SOTest1 : Control
    {
        private bool bar = true;
        private bool foo { get; set; }
    
        TextBox textBox;
        void Initialize()
        {
            textBox = new TextBox();
            textBox.Click += ClickHandler;
    
            this.Disposed += DisposeControl;
        }
    
        void ClickHandler(object sender, EventArgs e)
        {
            this.foo = bar;
        }
    
        void DisposeControl(object sender, EventArgs e)
        {
            textBox.Click -= ClickHandler;
            this.Disposed -= DisposeControl; // DOES THIS LINE MAKE SENSE?
        }
    }
