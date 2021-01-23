    public delegate void YouControlHandler(int relevantData1, string relevantData2);
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
    public class DependingClass
    {
         ClassContainingTreeView yourObject = new ClassContainingTreeView();
         public DependingClass()
         {
             yourObject.TreeViewClickedEvent += new YouControlHandler(EventHandler);
         }
         
         protected void EventHandler(int relevantData1, string relevantData2)
         {
                 // Handle event
         }
    }
    
