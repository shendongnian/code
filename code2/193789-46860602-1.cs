    public partial class MyComboBox : ComboBox
    {
    
        private IList<string> collectionList = null;
    
        public MyComboBox()
        {
            InitializeComponent();
            collectionList = new List<string>();
        }
        public MyComboBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    
        protected override void OnTextUpdate(EventArgs e)
        {
            IList<string> Values = collectionList
                .Where(x => x.ToLower().Contains(Text.ToLower()))
                .ToList<string>();
    
            this.Items.Clear();
            if (this.Text != string.Empty)
                this.Items.AddRange(Values.ToArray());
            else
                this.Items.AddRange(collectionList.ToArray());
    
            this.SelectionStart = this.Text.Length;
            this.DroppedDown = true;
        }
    
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            collectionList = this.Items.OfType<string>().ToList();
        }
    }
