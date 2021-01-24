    public class CheckTreeView: TreeView
    {
        public CheckTreeView()
        {
            CheckCommand = new RelayCommand<object>(o => MessageBox.Show(o?.ToString()));
        }
        public ICommand CheckCommand
        {
            get { return (ICommand)GetValue(CheckCommandProperty); }
            set { SetValue(CheckCommandProperty, value); }
        }
        public static readonly DependencyProperty CheckCommandProperty =
            DependencyProperty.Register("CheckCommand", typeof(ICommand), typeof(CheckTreeView), new PropertyMetadata(null));
    }
