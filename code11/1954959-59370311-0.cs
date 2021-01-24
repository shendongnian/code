    public enum NodeTypes
    {
        Subroutine,
        Folder
    }
    public class TreeNode
    {
        public string Name { get; set; }
        public NodeTypes NodeType { get; set; }
        public ObservableCollection<TreeNode> Nodes { get; } = new ObservableCollection<TreeNode>();
    }
