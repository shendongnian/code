    public class ChildViewModel1 :...
    {
    public ChildViewModel1(ParentViewModel parentViewModel)
    {
    _parentViewModel = parentViewModel;
    }
    private ParentViewModel _parentViewModel;
    public ParentViewModel ParentViewModel {get {return _parentViewModel; }}
    }
