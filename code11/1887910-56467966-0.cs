xaml
<ComboBox 
    ItemsSource="{Binding Agencies}"
    SelectedItem="{Binding SelectedAgency}"
    Text="{Binding SearchText}"
    IsTextSearchEnabled="False" 
    DisplayMemberPath="ComboText"
    IsEditable="True" 
    StaysOpenOnEdit="True"
    MinWidth="200" />
Another possible improvement is to expose the filter, so devs could easily change it. Turns out this can all be accomplished from the viewmodel. To keep things interesting I chose to use the `Agency`'s `ComboText` property for `DisplayMemberPath`, but its `Name` property for the custom filter. You could, of course, tweak this however you like.
c#
public class MainViewModel : ViewModelBase
{
    private readonly ObservableCollection<Agency> _agencies;
    public MainViewModel()
    {
        _agencies = GetAgencies();
        Agencies = (CollectionView)new CollectionViewSource { Source = _agencies }.View;
        Agencies.Filter = DropDownFilter;
    }
    #region ComboBox
    public CollectionView Agencies { get; } 
    private Agency selectedAgency;
    public Agency SelectedAgency
    {
        get { return selectedAgency; }
        set
        {
            if (value != null)
            {
                selectedAgency = value;
                OnPropertyChanged();
                SearchText = selectedAgency.ComboText;
            }
        }
    }
    private string searchText;
    public string SearchText
    {
        get { return searchText; }
        set
        {
            if (value != null)
            {
                searchText = value;
                OnPropertyChanged();
                if(searchText != SelectedAgency.ComboText) Agencies.Refresh();
            }
        }
    }
    private bool DropDownFilter(object item)
    {
        var agency = item as Agency;
        if (agency == null) return false;
        // No filter
        if (string.IsNullOrEmpty(SearchText)) return true;
        // Filtered prop here is Name != DisplayMemberPath ComboText
        return agency.Name.ToLower().Contains(SearchText.ToLower());
    }
    #endregion ComboBox
    private static ObservableCollection<Agency> GetAgencies()
    {
        var agencies = new ObservableCollection<Agency>
        {
            new Agency { AgencyNumber = 1, Name = "Foo", Title = "A" },
            new Agency { AgencyNumber = 2, Name = "Bar", Title = "C" },
            new Agency { AgencyNumber = 3, Name = "Elo", Title = "B" },
            new Agency { AgencyNumber = 4, Name = "Baz", Title = "D" },
            new Agency { AgencyNumber = 5, Name = "Hello", Title = "E" },
        };
        return agencies;
    }
}
The main gotchas:
- When the user enters a search and then selects an item from the filtered list, we want `SearchText` to be updated accordingly.
- When this happens, we don't want to refresh the filter. For this demo, we're using a different property for `DisplayMemberPath` and our custom filter. So if we would let the filter refresh, the filtered list would be empty (no matches are found) and the selected item would be cleared as well.
On a final note, if you specify the `ComboBox`'s `ItemTemplate`, you'll want to set `TextSearch.TextPath` instead of `DisplayMemberPath`.
