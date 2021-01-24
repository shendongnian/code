protected override IMvxViewsContainer InitializeViewLookup(IDictionary<Type, Type> viewModelViewLookup)
{
    viewModelViewLookup.Add(typeof(UserDatabaseUpgradeViewModel),typeof(UserDatabaseUpgradeView));
}
Hope this will solve also your problem. I'm using MvvmCross 6.4.x
