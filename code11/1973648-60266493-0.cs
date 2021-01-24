    public class DXTabItemAutomationPeerEx : DXTabItemAutomationPeer, ISelectionItemProvider {
        private DXTabItem TabItem => base.Owner as DXTabItem;
        private DXTabControl TabControl => TabItem.With((DXTabItem x) => x.Owner);
        public DXTabItemAutomationPeerEx(DXTabItem ownerCore) : base(ownerCore) { }
        protected override List<AutomationPeer> GetChildrenCore() {
            List<AutomationPeer> children = base.GetChildrenCore();
            foreach (var button in LayoutTreeHelper.GetVisualChildren(Owner).OfType<Button>())
                children.Add(new ButtonAutomationPeer(button));
            return children;
        }
        bool ISelectionItemProvider.IsSelected { get {
                if (TabControl != null) {
                    return TabControl.SelectedContainer == TabItem;
                }
                return false;
            } 
        }
    }
