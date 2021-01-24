    public class BasePresenter
    {
        protected void SharedMethod()
        {
            //Code that you need to call from both presenters
        }
    }
    public class MainPresenter : BasePresenter
    {
        IMyView _myView;
        public MainPresenter(IMyView myView)
        {
            _myView = myView;
        }
        private Foo()
        {
            SharedFunction();
        }
    }
    public class OtherPresenter : BasePresenter
    {
        public OtherPresenter(IMyView myView) : base()
        {
            _myView = myView;
        }
        private Bar()
        {
            SharedMethod();
        }
    }
