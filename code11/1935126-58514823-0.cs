    private void Form1_Load(object sender, EventArgs e)
    {
        this.treeView1.CheckBoxes = true;
        this.treeView1.DrawMode = TreeViewDrawMode.OwnerDrawAll;
        this.treeView1.DrawNode += new DrawTreeNodeEventHandler(treeViewGroupStatements_DrawNode);
        // root1
        TreeNode root1 = new TreeNode();
        root1.Text = "root1";
        TreeNode node11 = new TreeNode();
        node11.Text = "11";
        TreeNode node12 = new TreeNode();
        node12.Text = "12";
        root1.Nodes.Add(node11);
        root1.Nodes.Add(node12);
        treeView1.Nodes.Add(root1);
        // root2
        TreeNode root2 = new TreeNode();
        root2.Text = "root2";
        TreeNode node21 = new TreeNode();
        node21.Text = "21";
        TreeNode node22 = new TreeNode();
        node22.Text = "22";
        root2.Nodes.Add(node21);
        root2.Nodes.Add(node22);
        treeView1.Nodes.Add(root2);
        // get all root nodes
        foreach (var item in treeView1.Nodes)
        {
            if(((TreeNode)item).Level == 0)
            {
                HideList.Add(((TreeNode)item).Text, true);
            }
        }
    }
    // define a dictionary to store the root
    public Dictionary<string, bool> HideList = new Dictionary<string, bool>();
        
    private void treeViewGroupStatements_DrawNode(object sender, DrawTreeNodeEventArgs e)
    {
        HideLevelOfTreeView(e.Node);
        e.DrawDefault = true;
    }
    private void HideLevelOfTreeView(TreeNode tn)
    {
        if (HideList.ContainsKey(tn.Text))
            HideCheckBox(tn.TreeView, tn);
    }
    private const int TVIF_STATE = 0x8;
    private const int TVIS_STATEIMAGEMASK = 0xF000;
    private const int TV_FIRST = 0x1100;
    private const int TVM_SETITEM = TV_FIRST + 63;
    private void HideCheckBox(TreeView tvw, TreeNode node)
    {
        TVITEM tvi = new TVITEM();
        tvi.hItem = node.Handle;
        tvi.mask = TVIF_STATE;
        tvi.stateMask = TVIS_STATEIMAGEMASK;
        tvi.state = 0;
        SendMessage(tvw.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
    }
    [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
    private struct TVITEM
    {
        public int mask;
        public IntPtr hItem;
        public int state;
        public int stateMask;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpszText;
        public int cchTextMax;
        public int iImage;
        public int iSelectedImage; public int cChildren; public IntPtr lParam;
    }
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref TVITEM lParam);
