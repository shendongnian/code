public bool IsWorldsComboEnabled => WorldViewModel.Worlds != null
You might change to `public bool IsWorldsComboEnabled { get; set; }`
and evaluate the following expression
IsWorldsComboEnabled = WorldViewModel.Worlds != null;
whenever you change the property WorldViewModel.Worlds. 
In your case, where the property is a `ObservableCollection`, you might register to the CollectionChanged Event 
WorldViewModel.Worlds.CollectionChanged += MyCollectionChangedMethod;
and evaluate the expression there
private void MyCollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
{
  IsWorldsComboEnabled = WorldViewModel.Worlds != null;
}
