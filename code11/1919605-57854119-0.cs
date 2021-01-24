csharp
public class Dialog<T> : IDialogAble<T> where T : class, IEntity
{
    public IEntityService<T, object> Service { get; set; }
    public async Task Suchen(Expression<Func<T, bool>> criteria)
    {
        Cursor = Cursors.Wait;
        await Service.Search(criterian);
        Cursor = Cursors.Arrow;
    }
}
And you could still set the `Service` like this:
csharp
    Service = serviceFactory.CreateEntityService<MyObject, int>(context);
