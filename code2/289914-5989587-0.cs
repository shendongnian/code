    TResult result = Generator.AskResult();
    class Generator : Form
    {
        // set this result appropriately
        private TResult Result { get; set; }
        public static TResult AskResult()
        {
            var form = new Generator();
            form.ShowDialog();
            return form.Result; // or fetch a control's value directly
        }
    }
