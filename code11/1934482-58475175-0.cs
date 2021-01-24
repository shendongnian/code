public class SelectionViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private SelectionViewModel selectionViewModel;
    
    public SelectionViewModel SelectionViewModel
    {
        get
        {
            return this.selectionViewModel;
        }
        private set
        {
            this.selectionViewModel = value;
            PropertyChanged?.Invoke(this, nameof(SelectionViewModel));
        }
    }
}
Also you shouldn't use same names for type SelectionViewModel and property SelectionViewModel.
Since you wasn't provide a source code we can't figure out the exact cause of your error.
I hope it was helpful for you.
