    protected override void OnBeforeUninstall(IDictionary savedState)
{
    //Add this
    base.OnBeforeUninstall(savedState);
    if (ApplicationIsBusy())
        throw new ApplicationException("Prevent uninstall while application busy.");
