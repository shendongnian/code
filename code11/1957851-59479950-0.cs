using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
namespace CSAT.Models
{
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is BookDTO))
            return Binding.DoNothing;
			try
			{
                BookDTO bookDTO = value as BookDTO;
				using (MemoryStream stream = new MemoryStream(bookDTO.Image.ImageContent)) 
				{
					BitmapImage image = new BitmapImage();
					image.BeginInit();
					image.CacheOption = BitmapCacheOption.OnLoad;
					image.StreamSource = stream;
					image.EndInit();
					return image;
				}
			}
			catch
			{
				return Binding.DoNothing;
			}
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
**Step 2**: In your `View`:
<!--Your code here-->
<Window.Resources>
        <local:FileToImageConverter x:Key="fileToImageConverter"/>
</Window.Resources>
<!--Your code here-->
<!--Your image here-->
<Image Height="100" Width="Auto" Source="{Binding YourImage, Converter={StaticResource convertString2Image}}" />
**Step 3**: In `ViewModel`, create a full property to bind to `View`:
using System.ComponentModel;
namespace YourNamespace.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
		publicMainViewModel()
		{
			// Your code...
		}
		private BookDTO yourBookDTO;
        public BookDTO yourBookDTO
        {
            get { return yourBookDTO; }
            set { yourBookDTO = value; NotifyPropertyChanged("YourBookDTO"); }
        }
		
		public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string Obj)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(Obj));
            }
        }
	}
	public class ImageDTO
	{
		public int Id { get; set; }
		public int BookId { get; set; }
		public byte[] ImageContent { get; set; }
	}
	public class BookDTO
	{
		public int Id { get; set; }
		public String Title { get; set; }
		public String Author { get; set; }
		public ImageDTO Image { get; set; }
		public BookDTO()
		{
			Image = new ImageDTO();
		}
	}
}
**Step 4**: Your `ShowImage` method:
private void ShowImage(int id)
{
    this.YourBookDTO = someYourBookDTO; //Image.ImageContent property will be updated automatically
}
