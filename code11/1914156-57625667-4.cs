    public abstract class BasePresenter<TView> : IPrisenter<TView> where TView : IView {
        protected BasePresenter(TView view) {
            View = view;
        }
        protected TView View { get; private set; }
        public void Show() {
            View.Show();
        }
    }
    
    public class DrawPresenter : BasePresenter<IDrawView>, IDrawPresenter {
        public DrawPresenter(IDrawView view): base(view) {
        }
        public object SelectedDraws => View.GetGridDraw;
    }
