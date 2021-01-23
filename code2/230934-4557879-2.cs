    class CustomTB : TextBox
    {
        public CustomTB()
            : base()
        {
            CustomTB.SuppressEscape = false;
        }
        public static bool SuppressEscape { get; set; }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            CustomTB.SuppressEscape = (e.KeyCode == Keys.Escape);
            base.OnKeyUp(e);
        }
    }
