    public class ModelViewPropagationGroup<M, V> : List<IModelViewPropagationItem<M, V>>
        where M : BaseModel
        where V : IView
    {
        public ModelViewPropagationGroup(params IModelViewPropagationItem<M, V>[] items)
        {
            this.AddRange(items);
        }
    
        public void SyncAllToView(M model, V view)
        {
            this.ForEach(o => o.SyncToView(model, view));
        }
    
        public void SyncAllToModel(M model, V view)
        {
            this.ForEach(o => o.SyncToModel(model, view));
        }
    }
