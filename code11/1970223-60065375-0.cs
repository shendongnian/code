using ComicSort.Core;
using Microsoft.Win32;
using Prism.Commands;
using SharpCompress.Archives;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
namespace ComicSort.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Private Members
        private string _title = "ComicSort";
        
        #endregion
        #region Public Properties
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private ObservableCollection<BitmapImage> _thumbnail;
        public ObservableCollection<BitmapImage> Thumbnail
        {
            get { return _thumbnail; }
            set { SetProperty(ref _thumbnail, value); }
        }
        private BitmapImage _thumb;
        public BitmapImage Thumb
        {
            get { return _thumb; }
            set { SetProperty(ref _thumb, value); }
        }
        #endregion
        public MainWindowViewModel()
        {
            _thumbnail = new ObservableCollection<BitmapImage>();
        }
        private DelegateCommand _selectFileCommand;
        
        public DelegateCommand SelectFileCommand =>
            _selectFileCommand ?? (_selectFileCommand = new DelegateCommand(ExecuteSelectFileCommand));
        void ExecuteSelectFileCommand()
        {
            SelectFile();
        }
        private void SelectFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CBZ files (*.cbz)|*.cbz|CBR files (*.cbr)|*.cbr|All Files (*.*)|*.*";
            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string filename = openFileDialog.FileName;
                OpenArchive(filename);
                
            }
            
        }
        private void OpenArchive(string filename)
        {
                       
            var archive = ArchiveFactory.Open(filename);
            foreach (IArchiveEntry entry in archive.Entries)
            {
                if (!entry.IsDirectory)
                {
                    if (entry.Key != "ComicInfo.xml")
                    {
                        
                        Bitmap bitmap = LoadImage(entry);
                        DisplayImage(bitmap);
                        
                    }
                }
            }
        }
        private void DisplayImage(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);
            ms.Position = 0;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = ms;
            image.DecodePixelHeight = 128;
            image.CacheOption = BitmapCacheOption.OnDemand;
            image.EndInit();
            Thumb = image;
            }
        private Bitmap LoadImage(IArchiveEntry fileEntry)
        {
            
            Bitmap bitmap = (Bitmap)Bitmap.FromStream(fileEntry.OpenEntryStream());
            return bitmap;
        }
        
    }
}
