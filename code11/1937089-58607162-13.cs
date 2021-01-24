    // Common base type for the node collection and all tree nodes
    interface INode: INotifyPropertyChanged
    {
      string Name {get; set; }
      ObservableCollection<INode> Children { get; set; }
    }
