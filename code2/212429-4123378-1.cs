    using System.Collections.Generic;
    using System.Windows.Controls;
    
    namespace SilverlightApplication1
    {
        public partial class IsoImages : UserControl
        {
            public IsoImages()
            {
                InitializeComponent();
                List<ImageItem> images = new List<ImageItem>()
                                             {
                                                 new ImageItem("/images/Image1.jpg"), 
                                                 new ImageItem("/images/Image2.jpg"),
                                                 new ImageItem("/images/Image3.jpg"),
                                                 new ImageItem("/images/Image4.jpg")
                                             };
                this.ImageList.ItemsSource = images;
            }
        }
    
        public class ImageItem
        {
            public string Filename{ get; set; }
            public ImageItem( string filename )
            {
                Filename = filename;
            }
        }
    }
