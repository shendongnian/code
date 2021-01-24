    public interface ITreeNode
    {
        ObservableCollection<ITreeNode> Children { get; set; }
        string Name { get; set; }
        ITreeNode Parent { get; set; }
        void AddChild(ITreeNode child);
        void RemoveChild(ITreeNode child);
    }
