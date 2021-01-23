    public partial class MyComboBox : ComboBox
        {
    
            private IList<object> collectionList = null;
    
            public MyComboBox()
            {
                InitializeComponent();
                collectionList = new List<object>();
            }
            public MyComboBox(IContainer container)
            {
                container.Add(this);
                InitializeComponent();
            }
    
            protected override void OnTextUpdate(EventArgs e)
            {
                IList<object> Values = collectionList
                    .Where(x => x.ToString().ToLower().Contains(Text.ToLower()))
                    .ToList<object>();
    
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
                collectionList = this.Items.OfType<object>().ToList();
            }
        }
