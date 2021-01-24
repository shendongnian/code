    class MyController : MediaController
    {
        private Context _context;
        public MyController(Context context) : base(context)
        {
            _context = context;
        }
        private bool _isShowing { get; set; } = false;
        public override bool IsShowing { get { return _isShowing; } }
        public override void Show()
        {
            base.Show();
            _isShowing = true;
            ViewGroup parent = ((ViewGroup)this.Parent);
            parent.Visibility = ViewStates.Visible;
        }
        public override void Hide()
        {
            base.Hide();
            _isShowing = false;
           ViewGroup parent = ((ViewGroup)this.Parent);
            parent.Visibility = ViewStates.Gone;
        }
    }
