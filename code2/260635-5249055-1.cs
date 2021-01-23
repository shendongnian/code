    public class MyExpander: Expander
    {
        public event EventHandler<EventArgs> PreviewExpanded;
        
        public void OnPreviewExpanded()
        {
           PreviewExpanded(this,new EventArgs());
        }
        
        public override void OnExpanded()
        {
           PreviewExpanded()
           base.OnExpanded();
        }
    }
