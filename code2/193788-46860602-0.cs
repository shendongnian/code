    public partial class MyComboBox : ComboBox
        {
            private List<string> collectionList = null;
            public MyComboBox()
            {
                InitializeComponent();
                collectionList = new List<string>();
                this.TextUpdate += MyComboBox_TextUpdate;
            }
    
            private void MyComboBox_TextUpdate(object sender, EventArgs e)
            {
                IList<string> Values = collectionList
                    .OfType<string>()
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
    
            public MyComboBox(IContainer container)
            {
                container.Add(this);
                InitializeComponent();
            }
    
            protected override void OnCreateControl()
            {
                base.OnCreateControl();
                collectionList = this.Items.OfType<string>().ToList();
            }
        }
