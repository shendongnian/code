    class myForm: Form
    {
        // you weren't specific about the type of the `tb?value` fields
        private map As Dictionary<TextBox, Control>;
        public myForm()
        {
            // .... codes
            textbox1.LostFocus += OnExit;
            textbox2.LostFocus += OnExit;
            // repeats above for all textbox;
            map = new Dictionary<TextBox, Control> {
                 {textbox1, tb1value},
                 {textbox2, tb2value}
                 //...
            };
        }
        protected tb1value;
        protected tb2value;
