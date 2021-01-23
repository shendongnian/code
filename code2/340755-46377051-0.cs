    public class BasePresenter<T>
    {
    
    }
    
    public class Demo
    {
        public static TPresenter Initialize<TPresenter, TView>() where TPresenter: BasePresenter<TView>, new()
        {
            return null;
        }
    }
