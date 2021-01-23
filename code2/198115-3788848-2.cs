    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    
    namespace IsoStorageSilverlightApplication
    {
        public partial class MainPage : UserControl
        {
            public MainPage()
            {
                InitializeComponent();
            }
    
            private void saveButton_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "PNG Files (.png)|*.png|All Files (*.*)|*.*";
                dialog.FilterIndex = 1;
                if (dialog.ShowDialog() == true)
                {
                    System.IO.Stream fileStream = dialog.File.OpenRead();
    
                    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        // Create a directory at the root of the store.
                        if (!store.DirectoryExists("Images"))
                        {
                            store.CreateDirectory("Images");
                        }
    
                        using (IsolatedStorageFileStream isoStream = store.OpenFile(@"Images\UserImageFile.png", FileMode.OpenOrCreate))
                        {
                            byte[] bytes = new byte[fileStream.Length];
                            fileStream.Read(bytes, 0, (int)fileStream.Length);
                            isoStream.Write(bytes, 0, (int)fileStream.Length);
                        }
                    }
                }
            }
    
            private void loadButton_Click(object sender, RoutedEventArgs e)
            {
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (store.FileExists(@"Images\UserImageFile.png"))
                    {
                        using (var isoStream = store.OpenFile(@"Images\UserImageFile.png", FileMode.Open, FileAccess.Read))
                        {
                            var len = isoStream.Length;
                            BitmapImage b = new BitmapImage();
                            b.SetSource(isoStream);
                            image1.Source = b;
                        }
                    }
                }
            }
        }
    }
