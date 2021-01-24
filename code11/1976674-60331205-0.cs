<ListView ItemsSource="{Binding CavTogglesProperties}">
  <ListView.ItemTemplate>
    <DataTemplate>
      <ToggleButton Content="{Binding Text}" IsChecked="{Binding Toggle}" />
    </DataTemplate>
  </ListView.ItemTemplate>
</ListView>
To only show specific items, you should filter the list in the ViewModel, rather than binding the visibility. If the items visible doesn't change while being displayed, simply filter the list when you're populating it.
If, however, the visibilities will change and you want the view to reflect those changes, look at implementing a filter for your items source as explained in this question: [How do I Filter ListView in WPF?](https://stackoverflow.com/questions/2008481/how-do-i-filter-listview-in-wpf).
As you're already using an ObservableCollection and ObservableObject, everything should automatically update.
Showing a single item from a collection
=======================================
If I read your question wrong and you want to know how to show a single item from a collection, there's a couple of different ways of approaching this:
1. Expose the individual item as a property on the ViewModel so the View doesn't have to dig into the list.
2. Create a [converter](https://www.wpftutorial.net/ValueConverters.html) that takes in the collection and index, then pulls out the correct item.
I would highly recommend going with option 1, though, as it most conforms with MVVM, producing the cleanest and most testable code.
For example:
private ObservableCollection<CavitySelect> _CavTogglesProperties;
public ObservableCollection<CavitySelect> CavTogglesProperties
{
    get { return _CavTogglesProperties; }
    set
    {
        _CavTogglesProperties = value;
        RaisePropertyChanged("CavTogglesProperties");
    }
}
private CavitySelect _SpecificCavToggle;
public CavitySelect SpecificCavToggle
{
    get { return _SpecificCavToggle; }
    set
    {
        _SpecificCavToggle= value;
        RaisePropertyChanged("SpecificCavToggle");
    }
}
public MyViewModel()
{
    this.CavTogglesProperties = GetCavities();
    this.SpecificCavToggle = this.CavTogglesProperties[0];
}    
public ObservableCollection<CavitySelect> GetCavities()
{
    CavitySelect t11 = new CavitySelect();
    CavitySelect t12 = new CavitySelect();
    CavitySelect t13 = new CavitySelect();
    CavitySelect t14 = new CavitySelect();
    CavitySelect t15 = new CavitySelect();
    CavitySelect t16 = new CavitySelect();
    CavitySelect t26 = new CavitySelect();
    CavitySelect t21 = new CavitySelect();
    CavitySelect t22 = new CavitySelect();
    CavitySelect t23 = new CavitySelect();
    CavitySelect t24 = new CavitySelect();
    CavitySelect t25 = new CavitySelect();
    ObservableCollection<CavitySelect> temp = new ObservableCollection<CavitySelect>() {t11,t12,t13,t14,t15,t16,t21,t22,t23,t24,t25,t26};
    return temp;
}
<ToggleButton Content="{Binding SpecificCavToggle.Text}" IsChecked="{Binding SpecificCavToggle.Toggle}" />
