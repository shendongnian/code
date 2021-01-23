    public partial class MyComboBox : ComboBox
        {
            
            private IList<object> collectionList = null;
    
            public MyComboBox()
            {
                InitializeComponent();
                collectionList = new List<object>();
    
            }
            public MyComboBox(IContainer container)
                : this()
            {
                container.Add(this);
            }
    
            protected override void OnTextUpdate(EventArgs e)
            {
                try
                {
                    //base.OnTextUpdate(e);
                    IList<object> values = collectionList
                     .Where(x => x.ToString().ToLower().Contains(Text.ToLower()))
                     .ToList();
    
                    //Don't use Items.Clear() because the selectionstart resets to Zero
                    while (Items.Count > 0)
                    {
                        Items.RemoveAt(0);
                    }
    
                    this.Items.AddRange(values.ToArray());
    
                    this.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }
                catch(Exception ex)
                {
                    SelectedIndex = -1;
                    //MessageBox.Show(ex.Message);
                }
    
            }
    
            protected override void OnTextChanged(EventArgs e)
            {
                //base.OnTextChanged(e);
                if (this.Text == string.Empty)
                {
                    Items.Clear();
                    this.Items.AddRange(collectionList.ToArray());
                }
            }
    
            protected override void OnBindingContextChanged(EventArgs e)
            {
                base.OnBindingContextChanged(e);
                collectionList = this.Items.OfType<object>().ToList();
            }
        }
