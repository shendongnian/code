    public interface IModelViewPropagationItem<M, V>
        where M : BaseModel
        where V : IView
    {
        void SyncToView(M model, V view);
        void SyncToModel(M model, V view);
    }
    
    public class ModelViewPropagationItem<M, V, T> : IModelViewPropagationItem<M, V>
        where M : BaseModel
        where V : IView
    {
        private delegate void VoidDelegate();
    
        public Func<M, T> ModelValueGetter { get; private set; }
        public Action<M, T> ModelValueSetter { get; private set; }
        public Func<V, T> ViewValueGetter { get; private set; }
        public Action<V, T> ViewValueSetter { get; private set; }
    
        public ModelViewPropagationItem(Func<M, T> modelValueGetter, Action<V, T> viewValueSetter)
            : this(modelValueGetter, null, null, viewValueSetter)
        { }
    
        public ModelViewPropagationItem(Action<M, T> modelValueSetter, Func<V, T> viewValueGetter)
            : this(null, modelValueSetter, viewValueGetter, null)
        { }
    
        public ModelViewPropagationItem(Func<M, T> modelValueGetter, Action<M, T> modelValueSetter, Func<V, T> viewValueGetter, Action<V, T> viewValueSetter)
        {
            this.ModelValueGetter = modelValueGetter;
            this.ModelValueSetter = modelValueSetter;
            this.ViewValueGetter = viewValueGetter;
            this.ViewValueSetter = viewValueSetter;
        }
    
        public void SyncToView(M model, V view)
        {
            if (this.ViewValueSetter == null || this.ModelValueGetter == null)
                throw new InvalidOperationException("Syncing to View is not supported for this instance.");
    
            this.ViewValueSetter(view, this.ModelValueGetter(model));
        }
    
        public void SyncToModel(M model, V view)
        {
            if (this.ModelValueSetter == null || this.ViewValueGetter == null)
                throw new InvalidOperationException("Syncing to Model is not supported for this instance.");
    
            this.ModelValueSetter(model, this.ViewValueGetter(view));
        }
    }
