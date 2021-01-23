    using System.IO;
    using System.Windows;
    using System.Threading;
    using System.Windows.Media.Imaging;
    using System.Collections.Concurrent;
    using System;
    
    namespace WpfApplication3
    {
        public partial class MainWindow : Window
        {
            private BlockingCollection<BitmapImage> pictures = new BlockingCollection<BitmapImage>();
    
            public MainWindow()
            {
                InitializeComponent();
    
                var takeScreen = new Timer(o => TakeScreenshot(), null, 0, 10);
                new Thread(new ThreadStart(UpdateScreen)).Start();
            }
    
            private void TakeScreenshot()
            {
                var sc = new ScreenCapture();
                var img = sc.CaptureScreen();
    
                var stream = new MemoryStream();
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
    
                var image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();
    
                pictures.Add(image);
            }
    
            private void UpdateScreen()
            {
                while (true)
                {
                    var item = pictures.Take(); // blocks if count == 0
                    item.Dispatcher.Invoke(new Action(() => image1.Source = item));
                }
            }
        }
    }
