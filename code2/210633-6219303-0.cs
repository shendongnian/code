    public class TreeViewItemViewModel : INotifyPropertyChanged
    {
    	public IEnumerable<TreeViewItemViewModel> Childs { get; }
    	public bool IsSelected { get; set; }
    	public bool IsExpanded { get; set; }
    	(...)
    }
