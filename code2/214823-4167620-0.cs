    public Form1()
    {
        InitializeComponent();
        FindNode(treeView1.Nodes, ".txt");
        this.ActiveControl = treeView1;
    }  
    bool found = false;
    public void FindNode(TreeNodeCollection nodeCollection, string TextToFind)
    {
       foreach (TreeNode node in nodeCollection)
       {
           if (found)
              continue;
           if (node.Text.Contains(TextToFind))
           {
              treeView1.SelectedNode = node;
              TreeNode parentNode = node.Parent;
              while (parentNode != null)
              {
                  parentNode.Expand();
                  parentNode = parentNode.Parent;
              }
              found = true;
              break;
           }
           FindNode(node.Nodes, TextToFind);
        }
    }
