    public class MyViewModel<T> : MyViewModelBase where T : IMyModel , ModelBase
    {
        MyViewModel(T model) : base (model)   // T inherits ModelBase and implements IMyModel , so it is legal
        {
            // More here
        }
    }
