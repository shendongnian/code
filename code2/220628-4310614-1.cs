    see below code 
    so this fuction returns a stack in which top most item will be root and last item will be the immediate parent of element.
   
        public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
            TreeViewItem rootNode = new TreeViewItem();
            rootNode.Header = "RootNode";
            treeView.Items.Add(rootNode); 
             
            TreeViewItem subNode1 = new TreeViewItem(); 
            subNode1.Header = "SubNode1"; 
            rootNode.Items.Add(subNode1); 
             
            TreeViewItem subNode2 = new TreeViewItem(); 
            subNode2.Header = "SubNode2"; 
            rootNode.Items.Add(subNode2);
            TreeViewItem subNode3 = new TreeViewItem();
            subNode3.Header = "SubNode3";
            subNode2.Items.Add(subNode3); 
           
            
        }
        public static Stack<TreeViewItem> GetNodeParent(UIElement element)
        {
            Stack<TreeViewItem> tempNodePath = new Stack<TreeViewItem>();
            // Walk up the element tree to the nearest tree view item. 
            TreeViewItem container = element as TreeViewItem;
            while ((element != null))
            {
                element = VisualTreeHelper.GetParent(element) as UIElement;
                container = element as TreeViewItem;
                if(container!=null)
                tempNodePath.Push(container);
            }
            return tempNodePath;
        }
        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Stack<TreeViewItem> path = GetNodeParent(e.NewValue as UIElement);
        } 
      
    }
