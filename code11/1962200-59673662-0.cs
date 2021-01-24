    interface IViewModel 
    {
        IList<SelectListItem> PoolItems { get; set; }
    } 
    public class ViewModel1 : IViewModel 
    {
        ...
    }
    public class ViewModel2 : IViewModel 
    {
        ...
    }
    private static void SetPoolItems(IViewModel model, IList<PoolViewModel> pools)
    {
        ...
    }
