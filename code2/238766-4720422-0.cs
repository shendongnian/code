    public class TestPresenter : Presenter
    {
        ITestView _view;
        public TestPresenter(ITestView view)
        {
            _view.OnSomeEvent += new EventHandler(_view_OnSomeEvent);
        }
        void _view_OnSomeEvent(object sender, EventArgs e)
        {
            //code that will run when your StkQuit method is executed
        }
    }
