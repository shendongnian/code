    public abstract class BasicViewModel<TModelType> : ViewModelBase
        where TModelType : ModelBase
    {
        public BasicViewModel(TModelType model)
        {
            Model = model;
        }
    
        public TModelType Model { get; set; }
    }
    
    public class ModelBase
    {
    }
