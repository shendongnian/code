`c#
public VM()
{
    ActionMediator.Instance.PropertyChanged += new PropertyChangedEventHandler(Mediator_PropertyChanged);
}
private void Mediator_PropertyChanged(object sender, PropertyChangedEventArgs e)
{
    if (e.PropertyName == "IsAddGroupChecked")
        this.IsAddGroupChecked = ActionMediator.Instance.IsAddGroupChecked;
}
`
 2. Give an instance of your VM to your service so it can change the state directly (not a good idea though)
 3. Remove the `IsAddGroupChecked` property from your VM and bind your view directly to `ActionMediator.IsAddGroupChecked`
