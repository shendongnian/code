    public partial class MainWindow : Window
	{
		private WebClient _webClient;
		private ProgressBar[] _progressBars;
		private int _index = 0;
		public MainWindow()
		{
			InitializeComponent();
			_progressBars = new [] {progressBar1, progressBar2, progressBar3, progressBar4, progressBar5};
			ServicePointManager.DefaultConnectionLimit = 5;
		}
		private void button1_Click(object sender, RoutedEventArgs e)
		{
			Interlocked.Increment(ref _index);
			if (_index > _progressBars.Length)
				return;
			_webClient = new WebClient();
			_webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
			_webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
			
			_webClient.DownloadFileAsync(new Uri("http://download.thinkbroadband.com/5MB.zip"),
										 System.IO.Path.GetTempFileName(),
			                             _index);
		}
		private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs args)
		{
			var index = (int) args.UserState;
			_progressBars[index-1].Value = args.ProgressPercentage;
		}
		private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs args)
		{
			var index = (int)args.UserState;
			MessageBox.Show(args.Error == null
				                ? string.Format("Download #{0} completed!", index)
				                : string.Format("Download #{0} error!\n\n{1}", index, args.Error));
		}
	}
