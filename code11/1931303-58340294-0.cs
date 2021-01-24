    class MyForm : Form
    {
        // Note that `TaskCompletionSource` must have a generic-type argument.
        // If you don't care about the result then use a dummy null `Object` or 1-byte `Boolean` value.
        private TaskCompletionSource<Button> tcs;
        private readonly Button button;
        public MyForm()
        {
            this.button = new Button() { Text = "Click me" };
            this.Controls.Add( this.button );
            this.button.Click += this.OnButtonClicked;
        }
        private void OnButtonClicked( Object sender, EventArgs e )
        {
            if( this.tcs == null ) return;
 
            this.tcs.SetResult( (Button)sender );
        }
        internal async Task BatchLogicAsync()
        {
            this.tcs = new TaskCompletionSource<Button>();
            ProgressMessage = "Batch Logic Starts";
            Button clickedButton = await this.tcs.Task;
            ProgressMessage = "Batch Logic Ends";
        }
    }
