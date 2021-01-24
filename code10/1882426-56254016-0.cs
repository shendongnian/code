xaml
<ListView HasUnevenRows="True" SelectionMode="Single" ItemsSource="{Binding VisibleOrders}" ItemSelected="OnListViewItemSelected" ItemTapped="OnListViewItemTapped"/>
ViewModel:
c#
    public IList<MinRepresentation> VisibleOrders { get; private set; }
    
    void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
            {
                MinRepresentation selectedItem = e.SelectedItem as MinRepresentation;
            }
    
            void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
            {
                MinRepresentation tappedItem = e.Item as MinRepresentation;
    
            }
