    public partial class MainWindow : Window
    {
        IEventAggregator _eventAggregator;
        public MainWindow()
        {
            InitializeComponent();
            _eventAggregator = new EventAggregator();
            _eventAggregator.GetEvent<PubSubEvent<Request>>().Subscribe( payload =>
            {
                Thread.Sleep( 1000 ); // only fake work
                _eventAggregator.GetEvent<PubSubEvent<Response>>().Publish( new Response() );
            }, ThreadOption.BackgroundThread );
        }
        private async void Button_Click( object sender, RoutedEventArgs e )
        {
            ( (Button)sender ).IsEnabled = false;
            try
            {
                var tcs = new TaskCompletionSource<Response>();
                using ( var token = _eventAggregator.GetEvent<PubSubEvent<Response>>().Subscribe( payload =>
                {
                    tcs.TrySetResult( payload );
                }, ThreadOption.BackgroundThread ) )
                {
                    _eventAggregator.GetEvent<PubSubEvent<Request>>().Publish( new Request() );
                    await tcs.Task;
                }
            }
            finally
            {
                ( (Button)sender ).IsEnabled = true;
            }
        }
    }
    public class Request
    {
    }
    public class Response
    {
    }
