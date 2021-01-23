    public interface IView
    {
        void UpdateText(string test);
    }
    public class MyPresenter
    {
        private readonly IView _view;
        public MyPresenter(IView view)
        {
            _view = view;
        }
        private void SelectItem(string item)
        {
            _view.UpdateText(item);
        }
    }
    public partial class MyView : IView
    {
        private readonly MyPresenter _presenter;
        public MyView()
        {
            _presenter = new MyPresenter(this);
            combo.SelectedIndexChanged += OnSelectedIndexChanged;
        }
        public void UpdateText(string test)
        {
            textBox.Text = test;
        }
        private OnSelectedIndexChanged(Object sender, EventArgs e)
        {
            _presenter.SelectItem(combo.SelectedItem);
        }
    }
