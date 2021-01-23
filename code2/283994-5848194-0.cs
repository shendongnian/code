    public interface IWrapper<TModel>
    {
        TModel Model { get; }
    }
    public class WrapperCollection<TWrapper, TModel> : ObservableCollection<TWrapper> where TWrapper : IWrapper<TModel>
    {
        protected IList<TModel> modelList;
        public ReadOnlyObservableCollection<TWrapper> AsReadOnly { get; private set; }
        protected WrapperCollection(IList<TModel> modelList)
        {
            this.modelList = modelList;
            AsReadOnly = new ReadOnlyObservableCollection<TWrapper>(this);           
        }
        public WrapperCollection(IList<TModel> modelList, Func<TModel, TWrapper> newWrapper)
            :this(modelList)
        {
            foreach (TModel model in modelList)
                this.Items.Add(newWrapper(model));
        }
        public WrapperCollection(IList<TModel> modelList, Func<TModel, WrapperCollection<TWrapper, TModel>, TWrapper> newWrapper)
            : this(modelList)
        {
            foreach (TModel model in modelList)
                this.Items.Add(newWrapper(model, this));
        }
        protected override void ClearItems()
        {
            modelList.Clear();
            base.ClearItems();
        }
        protected override void InsertItem(int index, TWrapper item)
        {
            modelList.Insert(index, item.Model);
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            modelList.RemoveAt(index);
            base.RemoveItem(index);
        }
        protected override void SetItem(int index, TWrapper item)
        {
            modelList[index] = item.Model;
            base.SetItem(index, item);
        }
    }
