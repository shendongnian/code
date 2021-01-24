    public class Dialog<T, TKey> : IDialogAble<T> where T : class, IEntity
    {
        public IEntityService<T, TKey> Service { get; set; }
        public async Task Suchen(Expression<Func<T, bool>> criteria)
        {
            Cursor = Cursors.Wait;
            await Service.Search(criterian);
            Cursor = Cursors.Arrow;
        }
    }
