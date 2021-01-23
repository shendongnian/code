    public interface IItem
    {
    }
    public interface IMyItemsList
    {
        IEnumerable<IItem> GetList();
    }
    public interface IMyGenericList<out T> where T : IItem
    {
        IEnumerable<T> GetList();
    }
    public class MyList<T> : IMyGenericList<T>, IMyItemsList 
        where T : IItem
    {
        public IEnumerable<T> GetList()
        {
            return null;
        }
        IEnumerable<IItem> IMyItemsList.GetList()
        {
            return this.GetList().Cast<IItem>();
        }
    }
