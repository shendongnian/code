    public interface IMyFormView {
        string Title { get; set; }
    }
    public class MyForm : IMyFormView {
        public string Title {
            get { return titleTextBox.Text; }
            set { titleTextBox.Text = value; }
        }
        public MyForm()	{
            var presenter = new MyFormPresenter(this);
            presenter.Init();
        }
    }
    public class MyFormPresenter
    {
        private IMyView _view;
        public MyFormPresenter(IMyView view) {
            _view = view;
        }
        public void Init() {
            var title = "My title";
            _view.Title = title;
        }
    }
