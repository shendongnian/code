    class MyViewModel
    {
        ObservableCollection<SomeType> Collection;
        public MyViewModel()
        {
            FirstDropTarget = new YourHandler(this);
            SecondDropTarget = new YourOtherHandler(this);
        }
        public IDropTarget FirstDropTarget { get; }
        public IDropTarget SecondDropTarget { get; }
    }
