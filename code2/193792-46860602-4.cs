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
                base.OnTextUpdate(e);
    
                IList<object> values = collectionList
                 .Where(x => x.ToString().ToLower().Contains(Text.ToLower()))
                 .ToList();
    
                while (Items.Count > 0)
                {
                    Items.RemoveAt(0);
                }
    
                this.Items.AddRange(values.ToArray());
    
                this.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
    
            protected override void OnBindingContextChanged(EventArgs e)
            {
                base.OnBindingContextChanged(e);
                collectionList = this.Items.OfType<object>().ToList();
            }
        }
