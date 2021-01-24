    public class Parent : INotifyPropertyChanged
    {
        public Child ChildA
        {
            get; set;
        }
        public Child ChildB
        {
            get; set;
        }
        public ICommand RefreshBindingCommand { get; }
        public Parent()
        {
            ChildA = new Child(true);
            ChildB = new Child(false);
            RefreshBindingCommand = new RelayCommand(RefreshBindingCommand_Execute);
        }
        void RefreshBindingCommand_Execute(object obj)
        {
            RefreshBindings();
        }
        public void RefreshBindings()
        {
            ChildA.Notify(nameof(ChildA.Check));
            ChildB.Notify(nameof(ChildB.Check));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
