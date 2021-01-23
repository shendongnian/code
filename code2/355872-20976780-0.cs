	public class MyTreeList : DevExpress.XtraTreeList.TreeList
	{
	
		protected override DevExpress.XtraTreeList.Handler.TreeListHandler CreateHandler()
        {
            return new MyHandler(this);
        }
        internal DevExpress.XtraTreeList.Handler.TreeListHandler GetHandler() { return this.Handler; }
    }
    public class MyHandler : DevExpress.XtraTreeList.Handler.TreeListHandler
    {
        public MyHandler(TreeList tree) : base(tree) { }
        protected override TreeListControlState CreateState(TreeListState state)
        {
            if (state == TreeListState.IncrementalSearch && this.TreeList is MyTreeList)
                return new MyFinder((this.TreeList as MyTreeList).GetHandler());
            return base.CreateState(state);
        }
    }
    public class MyFinder : DevExpress.XtraTreeList.Handler.TreeListHandler.IncrementalSearchState
    {
        public MyFinder(DevExpress.XtraTreeList.Handler.TreeListHandler handler) : base(handler) { }
        protected override TreeListNode FindNode(FindNodeArgs e)
        {
            ////////////////////////////////////
			////////////////////////////////////
			////////////////////////////////////
            return base.FindNode(e);
        }
    }
