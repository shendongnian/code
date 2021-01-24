    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Button_Click( object sender, RoutedEventArgs e )
        {
            var dialog = new WaitWindow();
            var task = WorkAsync( dialog.Progress );
            var dialogTask = dialog.ShowDialogAsync();
            await task;
            dialog.Close();
            await dialogTask;
        }
        private async Task WorkAsync( IProgress<double> progress )
        {
            for ( int i = 0; i < 100; i++ )
            {
                progress.Report( i );
                await Task.Delay( 25 ).ConfigureAwait( false );
            }
        }
    }
