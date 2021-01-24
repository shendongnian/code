    public List<MyGroup>  GroupList {
    get{
         return groupList;
    }
    set{
         groupList = value;
         OnPropertyChanged(nameof(GroupList));
    }
