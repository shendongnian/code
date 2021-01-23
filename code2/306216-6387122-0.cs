    public class PartListBindingList : BindingList<PartListBindingItem>
    {
        private readonly MyDatabase _Database;
        private bool _IsInitialized = false;
        public PartListBindingSource(MyDatabase database)
        {
            _Database = database;
            foreach (var part in _Database.Parts)
            {
                var item = new PartListBindingItem()
                {
                    PartID = part.PartID
                    Name = part.Name,
                    Description = part.Description
                };
                Add(item);
                BindItem(item);
            }
            _IsInitialized = true;
        }
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            base.OnListChanged(e);
            if (!_IsInitialized) return;
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    // Add new item to database
                    break;
                case ListChangedType.ItemDeleted:
                    // Add new item to database
                    break;
            }
        }
        private void BindItem(PartListBindingItem item)
        {
            item.Changed += (s, e) =>
            {
                // Update the entry in the database.
            };
        }
    }
    public class PartListBindingItem
    {
        public event EventHandler Changed;
        private int _PartID;
        private string _Name;
        private string _Description;
        public int PartID
        {
            get { return _PartID; }
            set
            {
                _PartID= value;
                OnChanged();
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnChanged();
            }
        }
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description= value;
                OnChanged();
            }
        }
        private OnChanged()
        {
            var changed = Changed;
            if (changed != null)
            {
                changed(this, EventArgs.Empty);
            }
        }
    }
