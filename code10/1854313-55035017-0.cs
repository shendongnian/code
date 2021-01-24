	public partial class Form1 : Form
	{
		private Subject<string> _enqueue = new Subject<string>();
		private IDisposable _subscription = null;
	
		public Form1()
		{
			InitializeComponent();
			
			string ColorSeparator = "42";
			int imageRotationNumber = 42;
	
			IObservable<string> query =
				from file in _enqueue
				from ImageListSorted in Observable.Start(() => ImageBuilder(file, ColorSeparator))
				from RotateCMYK in Observable.Start(() => Rotate(ImageListSorted.CMYKmages, imageRotationNumber))
				select file;
				
			_subscription = query.Subscribe(f => System.IO.File.Delete(f));
	
			_enqueue.OnNext(@"C:\test\yourtestfile1.txt");
			_enqueue.OnNext(@"C:\test\yourtestfile2.txt");
			_enqueue.OnNext(@"C:\test\yourtestfile3.txt");
		}
	
	
		private CreateCMYKAndImpositionImageList ImageBuilder(string JobImages, string colorDelimiter)
		{
			return new CreateCMYKAndImpositionImageList(JobImages, colorDelimiter);
		}
		
		private RotateImages Rotate(Dictionary<string, string> imageList, int RotationNumber)
		{
			return new RotateImages(imageList, RotationNumber);
		}
	}
