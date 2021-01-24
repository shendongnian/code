csharp
public class Item : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public string Id { get; set; }
    private string _text;
    public string Text
    {
        get => _text;
        set
        {
            if (_text != value)
            {
                _text = value;
                NotifyPropertyChanged();
            }
        }
    }
    private string _description;
    public string Description
    {
        get => _description;
        set
        {
            if (_description != value)
            {
                _description = value;
                NotifyPropertyChanged();
            }
        }
    }
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
However, I would also recommend you don't bind to nested properties, since that can be problematic. Thus, instead of binding to `Item.Text` and `Item.Description`, just bind directly to properties in your viewmodel.
For example, in `ItemDetailViewModel` you could create two properties called `ItemText` and `ItemDescription`:
csharp
public string ItemText => Item?.Text;
public string ItemDescription => Item?.Description;
xaml
<!-- Updated bindings -->
<StackLayout Spacing="20" Padding="15">
  <Label Text="Text:" FontSize="Medium" />
  <Label Text="{Binding ItemText}" FontSize="Small"/>
  <Label Text="Description:" FontSize="Medium" />
  <Label Text="{Binding ItemDescription}" FontSize="Small"/>
</StackLayout>
To make sure these properties notify about their changes whenever the corresponding properties of the `Item` change, you will need to subscribe to the event `Item.PropertyChanged` so you can propagate the updates:
csharp
// (Assuming the base viewmodel implements INotifyPropertyChanged the same way than Item)
public class ItemDetailViewModel : BaseViewModel
{
    private Item _item;
    public Item Item
    {
        get => _item;
        set
        {
            if (_item != value)
            {
                if (_item != null)
                {
                    // Unsubscribe from the old item
                    _item.PropertyChanged -= OnItemPropertyChanged;
                }
                _item = value;
                NotifyPropertyChanged();
                if (value != null)
                {
                    // Subscribe to the new item
                    value.PropertyChanged += OnItemPropertyChanged;
                }
                // Since the entire item has changed, we notify 
                // about changes in all the dependant properties
                Title = Item?.Text;
                NotifyPropertyChanged(nameof(ItemText));
                NotifyPropertyChanged(nameof(DescriptionText));
            }
        }
    }
    public string ItemText => Item?.Text;
    public string ItemDescription => Item?.Description;
    public ItemDetailViewModel(Item item = null)
    {
        Item = item;
    }
    private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // When a property of the item changes, we propagate the changes
        // to the properties of this viewmodel that now depend on it
        if (e.PropertyName == nameof(Text))
        {
            Title = Item?.Text;
            NotifyPropertyChanged(nameof(ItemText));
        }
        else if (e.PropertyName == nameof(Description))
        {
            NotifyPropertyChanged(nameof(ItemDescription));
        }
    }
}
This code is a little bit messy and could be improved to make it more elegant, but I hope you get the idea.
  [1]: https://docs.microsoft.com/en-us/dotnet/framework/winforms/how-to-implement-the-inotifypropertychanged-interface
