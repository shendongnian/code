    public partial class Form1 : Form
    {
        // A Class member variable to hold images, to be used by both the 
        // TreeView AND the ListView:
        ImageList _myImagelist;
        public Form1()
        {
            InitializeComponent();
            // Initialize your memeber variable:
            _myImagelist = new ImageList();
            // Add some hokey test images for this arbitrary example:
            _myImagelist.Images.Add("Image1", Properties.Resources.SomeImage);
            _myImagelist.Images.Add("Image2", Properties.Resources.AnotherImage);
            // Some crude code to populate the list with test data:
            TreeView lst = this.treeView1;
            lst.ShowPlusMinus = true;
            // Set a reference to your member variable:
            lst.ImageList = _myImagelist;
            // Now populate your tree nodes and subnodes:
            TreeNode parent;
            //A parent . . .
            parent = lst.Nodes.Add("FirstNode", "Image One", "Image1");
            //  . . . with children:
            parent.Nodes.Add("P1:S1", "Parent One Child One", "Image1");
            parent.Nodes.Add("P1:S2", "Parent One Child Two", "Image1");
            // Another parent . . .
            parent = lst.Nodes.Add("SecondNode", "Image Two", "Image2");
            // . . . More children:
            parent.Nodes.Add("P2:S1", "Parent Two Child One", "Image2");
            parent.Nodes.Add("P2:S2", "Parent Two Child Two", "Image2");
        }
        // Event handler for the AfterSelect Event:
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode nd = e.Node;
            this.FillList(nd);
        }
        
        private void FillList(TreeNode node)
        {
            ListView lv = this.listView1;
            lv.View = View.List;
            // Set the reference to your same member variable:
            lv.SmallImageList = _myImagelist;
            lv.Items.Clear();
            foreach (TreeNode nd in node.Nodes)
            {
                // The Listview also has an override of the .Add method which accepts the image KEY as
                // an argument. The nd.ImageKey property returns a string, which the ListView item recognizes
                // as the key for an item in the referenced ImageList:
                ListViewItem newItem = new ListViewItem(nd.Text, nd.ImageKey);
                lv.Items.Add(nd.Name, nd.Text, nd.ImageKey);
            }
        }
    }
