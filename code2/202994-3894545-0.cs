    public class foo : INotifyPropertyChanged
    {
        protected ObservableCollection<ChildFoo> _Children = new ObservableCollection<ChildFoo>();
    
    public foo()    {    }
    protected void AddChild(ChildFoo oldChild)
    {
        DoAttachLogic(newChild);
        _Children.Add(newChild);
        NotifyPropertyChange("Children");
    }
    protected void RemoveChild(ChildFoo oldChild)
    {
        DoRemoveLogic(oldChild);
        _Children.Remove(oldChild);
        NotifyPropertyChange("Children");
    }
     
    public ChildFoo this[int n]
    {
        get
        {
            return _Children[n];
        }
    }
    
    }
