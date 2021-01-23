    public delegate YouControlHandler(int relevantData1, string relevantData2);
    public class ClassContainingTreeView
    {
        public event YouControlHandler TreeViewClickedEvent;
        public void OnTreeViewClicked(object sender, EventArgs)
        {
            // Handle request locally first and extract relevantData1/2
            if(TreeViewClickedEvent != null)
                TreeViewClickedEvent(relevantData1, relevantData2);
        }
    }
    
