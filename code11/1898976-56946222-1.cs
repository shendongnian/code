    public class MyTreeViwe : TreeView
    {
        public bool IsSuspendSelection { get; set; }
        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            if (IsSuspendSelection)
                e.Cancel = true;
            else base.OnBeforeSelect(e);
        }
    }
	
