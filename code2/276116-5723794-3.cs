    public partial class ReferencesCollectionEditorForm : Form
    {
        public ReferencesCollectionEditorForm(Control[] available, Control[] selected)
        {
            this.InitializeComponent();
            List<Control> sel = new List<Control>(selected);
            this.available = available;
            if (available != null)
                foreach (var eachControl in available)
                    this.checkedListBox1.Items.Add(new Item(eachControl),
                        selected != null && sel.Contains(eachControl));
        }
    
        class Item
        {
            public Item(Control ctl) { this.control = ctl; }
            public Control control;
            public override string ToString()
            {
                return this.control.GetType().Name + ": " + this.control.Name;
            }
        }
    
        Control[] available;
    
        public Control[] Selected
        {
            get
            {
                List<Control> selected = new List<Control>(this.available.Length);
                foreach (Item eachItem in this.checkedListBox1.CheckedItems)
                    selected.Add(eachItem.control);
                return selected.ToArray();
            }
        }
    }
