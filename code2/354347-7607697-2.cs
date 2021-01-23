    public interface IMyFormView {
        void Show();
    }
    public class MyForm : IMyFormView {
        public MyForm()	{
            var presenter = new MyFormPresenter(this);
            presenter.Init();
        }
        public void Show() {
            usercontrol1.fill();
        }
    }
    public class MyFormPresenter
    {
        private IMyView _view;
        public MyFormPresenter(IMyView view) {
            _view = view;
        }
        public void Init() {
            _view.Show();
        }
    }
