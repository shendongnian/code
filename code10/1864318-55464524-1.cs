    using System;
    using Windows.Graphics.Imaging;
    using Windows.Storage;
    using Windows.Storage.Pickers;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Media.Imaging;
    
    namespace App1
    {
        public sealed partial class MainPage
        {
            public MainPage()
            {
                InitializeComponent();
            }
    
            private async void Button_Click(object sender, RoutedEventArgs e)
            {
                var picker = new FileOpenPicker();
    
                picker.FileTypeFilter.Add(".gif");
    
                picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
    
                var file = await picker.PickSingleFileAsync();
                if (file == null)
                    return;
    
                var stream = await file.OpenAsync(FileAccessMode.Read);
    
                var decoder = await BitmapDecoder.CreateAsync(stream);
    
                var frame = await decoder.GetFrameAsync(0);
    
                var softwareBitmap = await frame.GetSoftwareBitmapAsync();
    
                var convert = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
    
                var softwareBitmapSource = new SoftwareBitmapSource();
    
                await softwareBitmapSource.SetBitmapAsync(convert);
    
                Image.Source = softwareBitmapSource;
            }
        }
    }
