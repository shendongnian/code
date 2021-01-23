    public class RibbonService
    {
        public PrioritySet<RibbonTab> Tabs { get; private set; }
        public PrioritySet<object> QuickAccess { get; private set; }
        public PrioritySet<ContextualGroup> ContextualGroup { get; private set; }
    }
