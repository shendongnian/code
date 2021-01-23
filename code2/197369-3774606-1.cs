    public partial class MainWindow : Window
    {
        private readonly object dummyNode = null;
        public MainWindow()
        {
            InitializeComponent();
            Action<ItemCollection> action = RenderTreeView;
            action.BeginInvoke(treeView1.Items, null, null);
        }
        private void RenderTreeView(ItemCollection root)
        {
            foreach (string drive in Directory.GetLogicalDrives())
            {
                var driveInfo = new DriveInfo(drive);
                if (driveInfo.IsReady)
                {
                    CreateAndAppendTreeViewItem(root, drive, drive, drive);
                }
            }
        }
        private void FolderExpanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem) sender;
            if (item.Items.Count == 1 && item.Items[0] == dummyNode)
            {
                item.Items.Clear();
                var directory = item.Tag as string;
                if (string.IsNullOrEmpty(directory))
                {
                    return;
                }
                Action<TreeViewItem, string> action = ExpandTreeViewNode;
                action.BeginInvoke(item, directory, null, null);
            }
        }
        private void ExpandTreeViewNode(TreeViewItem item, string directory)
        {
            foreach (string dir in Directory.GetDirectories(directory))
            {
                var tempDirInfo = new DirectoryInfo(dir);
                bool isSystem = ((tempDirInfo.Attributes & FileAttributes.System) == FileAttributes.System);
                if (!isSystem)
                {
                    CreateAndAppendTreeViewItem(item.Items, tempDirInfo.Name, dir, dir);
                }
            }
        }
        private void AddChildNodeItem(ItemCollection collection, TreeViewItem subItem)
        {
            if (Dispatcher.CheckAccess())
            {
                collection.Add(subItem);
            }
            else
            {
                Dispatcher.Invoke(new Action(() => AddChildNodeItem(collection, subItem)));
            }
        }
        private void CreateAndAppendTreeViewItem(ItemCollection items, string header, string tag, string toolTip)
        {
            if (Dispatcher.CheckAccess())
            {
                var subitem = CreateTreeViewItem(header, tag, toolTip);
                AddChildNodeItem(items, subitem);
            }
            else
            {
                Dispatcher.Invoke(new Action(() => CreateAndAppendTreeViewItem(items, header, tag, toolTip)));
            }
        }
        private TreeViewItem CreateTreeViewItem(string header, string tag, string toolTip)
        {
            var treeViewItem = new TreeViewItem {Header = header, Tag = tag, ToolTip = toolTip};
            treeViewItem.Items.Add(dummyNode);
            treeViewItem.Expanded += FolderExpanded;
            return treeViewItem;
        }
    }
