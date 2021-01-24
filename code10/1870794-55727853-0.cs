    public partial class MainWindow : Window
    {
        public static RoutedCommand ColorCmd = new RoutedCommand();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ColorCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            xxxx.ColorCmdExecuted(e.Source);
        }
        private void ColorCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = xxxx.ColorCmdCanExecute(e.Source);
        }
    }
    public class xxxx
    {
        public static void ColorCmdExecuted(object parameter)
        {
            var target = parameter as Panel;
            if (target != null)
            {
                target.Background = target.Background == Brushes.AliceBlue ? Brushes.LemonChiffon : Brushes.AliceBlue;
            }
        }
        public static bool ColorCmdCanExecute(object parameter)
        {
            return parameter is Panel;
        }
    }
