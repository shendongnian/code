    public interface IViewBase
    {
    }
    public abstract class ViewBase<IPresneter, TIView> : UserControl
                                                       , IViewBase
    {
    }
    
    public class AView : ViewBase<ConcretePresenter, IView>
    {
    }
