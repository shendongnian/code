C#
public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (value == _isSelected) { return; }
            _isSelected = value;
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
             //Invoke Scroll
             DataGrid.ScrollIntoView(this);
        }
    }
    public int Data { get; }
    public ViewModel(int data) => Data = data;
    //DataGrid Reference
    public DataGrid DataGrid { get; set; }
}
Then just add the reference when you construct the ViewModels
C#
var data = Enumerable.Range(1, 100).Select(x => new ViewModel(x) { DataGrid = dg }).ToList();
It seems like the best way to avoid virtualization and having to call from the View in this case.
