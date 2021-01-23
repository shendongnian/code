        public Form1()
        {
            InitializeComponent();
    
            Assembly assembly = Assembly.GetAssembly(typeof (DateTime));
            foreach (var exportedType in assembly.GetExportedTypes())
            {
                var parentNode = treeView1.Nodes.Add(exportedType.Name);
                AddNodes(exportedType, parentNode);
            }
        }
    
        private void AddNodes(Type type,TreeNode node)
        {
            foreach (var nestedType in type.GetNestedTypes())
            {
                var nestedNode = node.Nodes.Add(nestedType.Name);
                AddNodes(nestedType, nestedNode);
            }
        }
