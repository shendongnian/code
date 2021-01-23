    public class DetailsListView : ListView
    {
        public new class ListViewItemCollection : ListView.ListViewItemCollection
        {
            private DetailsListView m_owner;
            public ListViewItemCollection(DetailsListView owner)
                : base(owner)
            {
                m_owner = owner;
            }
    
            public override void Clear()
            {
                base.Clear();
                m_owner.FireChanged();
            }
        }
    
        private void FireChanged()
        {
            base.OnSelectedIndexChanged(EventArgs.Empty);
        }
    
    
        private ListViewItemCollection m_Items;
    
        public DetailsListView()
        {
            m_Items = new ListViewItemCollection(this);
    
            View = View.Details;
            GridLines = true;
            HideSelection = false;
            FullRowSelect = true;
        }
    
        public new ListViewItemCollection Items
        {
            get
            {
                return m_Items;
            }
        }
    
    }
