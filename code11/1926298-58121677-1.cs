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
If you go for this one, it is also a good idea to modify you mediator to avoid looping
`c#
private bool isAddGroupChecked = false;
public bool IsAddGroupChecked
{
    get { return isAddGroupChecked; }
    set
    {
        if (value != isAddGroupChecked)
        {
            isAddGroupChecked = value;
            NotifyPropertyChanged();
        }
    }
}
`
 2. Give an instance of your VM to your service so it can change the state directly (not a good idea though)
 3. Remove the `IsAddGroupChecked` property from your VM and bind your view directly to `ActionMediator.IsAddGroupChecked`
