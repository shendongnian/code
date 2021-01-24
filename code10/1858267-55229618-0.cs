    public partial class Orders
    {
    public Orders()
    {
        Order_Details = new ObservableListSource<Order_Details>();
    }
    [Key]
    public int OrderID { get; set; }
    ……………
    public virtual ObservableListSource<Order_Details> Order_Details { get; set; }
    }
    public class ObservableListSource<T> : ObservableCollection<T>, IListSource
            where T : class
    {
        private IBindingList _bindingList;
        bool IListSource.ContainsListCollection { get { return false; } }
        IList IListSource.GetList()
        {
            return _bindingList ?? (_bindingList = this.ToBindingList());
        }
        private bool _bRemoveInProgress = false;
        protected override void RemoveItem(int index)
        {
            if (!_bRemoveInProgress && index>=0)
            {
                _bRemoveInProgress = true;
                DbContext cntx = this[index].GetDbContextFromEntity();
                Type tp = this[index].GetDynamicProxiesType();
                cntx.Set(tp).Remove(this[index]);
                base.RemoveItem(index);
            }
            _bRemoveInProgress = false;
        }
    }
    public static class DbContextExtender
    {
        public static Type GetDynamicProxiesType(this object entity)
        {
            var thisType = entity.GetType();
            if (thisType.Namespace == "System.Data.Entity.DynamicProxies")
                return thisType.BaseType;
            return thisType;
        }
        public static DbContext GetDbContextFromEntity(this object entity)
        {
            var object_context = GetObjectContextFromEntity(entity);
            if (object_context == null)
                return null;
            return new DbContext(object_context, dbContextOwnsObjectContext: false);
            //return object_context;
        }
        private static ObjectContext GetObjectContextFromEntity(object entity)
        {
            var field = entity.GetType().GetField("_entityWrapper");
            if (field == null)
                return null;
            var wrapper = field.GetValue(entity);
            var property = wrapper.GetType().GetProperty("Context");
            var context = (ObjectContext)property.GetValue(wrapper, null);
            return context;
        }
    }
