<ListView ItemsSource="{Binding Cities}" SelectedItem="{Binding SelectedCity">
in the SelectedCity setter you can update the `Persons` collection like
class PersonsByCitiesViewModel
{
public City SelectedCity
{
get{}
set
{
  Persons = LoadPersons(value);
}
}
public ListCollectionView LoadPersons(City selected)
{
  var persons = LoadAll();
  if (selected != null)
    persons = persons.Where(_ => _.CityId = selected.CityId);
  return new ListCollectionView(persons);
}
}
