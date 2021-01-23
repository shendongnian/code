    class PrintMenuManager : IMenuStateManager
    {
        private readonly ToolStripItem[] _items;
        
        // this constructor can accept several menu elements
        public PrintMenuManager(params ToolStripItem[] items)
        {
            _items = items;
        }
        public void UpdateState(ISelectedNodeInfo node)
        {
            foreach (ToolStripItem item in _items)
            {
                // if node is printable, enable
                // all "print" menu items and buttons
                item.Enabled = (node.IsPrintable);
            }
        }
    }
