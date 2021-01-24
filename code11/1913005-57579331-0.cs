public Persons OwnersSelectedItem
{
    get { return _ownersSelectedItem; }
}
public async Task SetOwnersSelectedItem(Person newPerson)
{
    _ownersSelectedItem = newPerson;
    await ownersSelectionChanged();
    base.RaisePropertyChangedEvent("OwnersSelectedItem");
}
