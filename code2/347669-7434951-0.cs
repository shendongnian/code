    public class MyViewModel<T> : MyViewModelBase where T : IMyModel , ModelBase
    {
        MyViewModel(T Model) : base (Model)   // <- Invalid Polymorphism!
        {
            // More here
        }
    }
