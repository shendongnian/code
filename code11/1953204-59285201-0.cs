    	public partial class CheckTreeView : TreeView
    	{
    		public CheckTreeView()
    		{
    			InitializeComponent();
    			processNode(this);
    		}
    		void processNode(ItemsControl node)
    		{
    			node.ItemContainerGenerator.StatusChanged += (sender, args) =>
    			{
    				ItemContainerGenerator itemContainerGenerator = ((ItemContainerGenerator)sender);
    				if (itemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
    				{
    					for (int i = 0; i < itemContainerGenerator.Items.Count; i++)
    					{
    						TreeViewItem treeViewItem =
    							(TreeViewItem) itemContainerGenerator.ContainerFromIndex(i);
    						treeViewItem.Loaded += (o, eventArgs) =>
    						{
    							CheckBox checkBox = FindVisualChild<CheckBox>(treeViewItem);
    							checkBox.Click += CheckBox_Click;
    						};
    						processNode(treeViewItem);
    					}
    				}
    			};
    		}
    		public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
    		{
    			if (obj != null)
    			{
    				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
    				{
    					var child = VisualTreeHelper.GetChild(obj, i);
    					if (child is T)
    					{
    						return (T)child;
    					}
    					T childItem = FindVisualChild<T>(child);
    					if (childItem != null) return childItem;
    				}
    			}
    			return null;
    		}
    		private void CheckBox_Click(object sender, RoutedEventArgs e)
    		{
    		}
    	}
