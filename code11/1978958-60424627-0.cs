`CSharp
public class HomeViewModel 
{
    /* Ommited code  */
    public override async Task Initialize()
    {
        IsBusy = true;
        var items = await MyCustomService.GetItemsAsync();
        // ...
    }
    public override void ViewAppeared()
    {
        base.ViewAppeared();
        if (true)
        {
            NavigationService.Navigate<MissionsViewModel>();
        }
    }
}
`
