    public delegate void PreviewSelectionChangedEventHandler(object p_oSender, PreviewSelectionChangedEventArgs p_eEventArgs);
    public class PreviewSelectionChangedEventArgs
    {
        internal PreviewSelectionChangedEventArgs(IList p_lAddedItems, IList p_lRemovedItems)
        {
            this.AddedItems = p_lAddedItems;
            this.RemovedItems = p_lRemovedItems;
        }
        public bool Cancel { get; set; }
        public IList AddedItems { get; private set; }
        public IList RemovedItems { get; private set; }
    }
    public class TabControl2: TabControl
    {
        public event PreviewSelectionChangedEventHandler PreviewSelectionChanged;
        private int? m_lLastSelectedIndex;
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            // déterminer si on doit annuler la sélection
            PreviewSelectionChangedEventArgs eEventArgs = new PreviewSelectionChangedEventArgs(e.AddedItems, e.RemovedItems);
            if (m_lLastSelectedIndex.HasValue)
                if (PreviewSelectionChanged != null)
                    PreviewSelectionChanged(this, eEventArgs);
            // annuler (ou pas) la sélection
            if (eEventArgs.Cancel)
                this.SelectedIndex = m_lLastSelectedIndex.Value;
            else
                m_lLastSelectedIndex = this.SelectedIndex;
        }
    }
