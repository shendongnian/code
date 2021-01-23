    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using System.IO;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for ImageFromByteArray.xaml
        /// </summary>
        public partial class ImageFromByteArray : Window
        {
    
    
            public byte[] ByteArray
            {
                get
                {
                    return (byte[])GetValue(ByteArrayProperty);
                }
                set
                {
                    SetValue(ByteArrayProperty, value);
                }
            }
    
            // Using a DependencyProperty as the backing store for ByteArray.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ByteArrayProperty =
                DependencyProperty.Register("ByteArray", typeof(byte[]), typeof(ImageFromByteArray));
    
    
    
            public BitmapImage ImageSource
            {
                get { return (BitmapImage)GetValue(ImageSourceProperty); }
                set { SetValue(ImageSourceProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ImageSourceProperty =
                DependencyProperty.Register("ImageSource", typeof(BitmapImage), typeof(ImageFromByteArray), new UIPropertyMetadata(null));
    
    
            public ImageFromByteArray()
            {
                InitializeComponent();
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                if (dlg.ShowDialog().GetValueOrDefault())
                {
                    FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                    ByteArray = new byte[fs.Length];
                    fs.Read(ByteArray, 0, System.Convert.ToInt32(fs.Length));
                    fs.Close();
                    ImageSource = ImageFromBytearray(ByteArray);
                }
            }
    
    
            public BitmapImage ImageFromBytearray(byte[] imageData)
            {
    
                if (imageData == null)
                    return null;
                MemoryStream strm = new MemoryStream();
                strm.Write(imageData, 0, imageData.Length);
                strm.Position = 0;
                System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
    
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                MemoryStream memoryStream = new MemoryStream();
                img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                memoryStream.Seek(0, SeekOrigin.Begin);
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
    
                return bitmapImage;
            }
        }
    }
