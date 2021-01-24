    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    namespace ImagePickerDropdownSample
    {
        // Learn more about making custom code visible in the Xamarin.Forms previewer
        // by visiting https://aka.ms/xamarinforms-previewer
        [DesignTimeVisible(false)]
        public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                InitializeComponent();
            
                Images = new ObservableCollection<ImageSource>();
                Images.Add(new FileImageSource() { File = "image1.png" });
                Images.Add(new FileImageSource() { File = "image2.png" });
                Images.Add(new FileImageSource() { File = "image3.png" });
                SelectedImage = Images[0];
                BindingContext = this;
            }
            ImageSource _selectedImage;
            public ImageSource SelectedImage
            {
                get
                {
                    return _selectedImage;
                }
                set
                {
                    if (_selectedImage != value)
                    {
                        _selectedImage = value;
                        OnPropertyChanged(nameof(SelectedImage));
                    }
                }
            }
            ObservableCollection<ImageSource> _images;
            public ObservableCollection<ImageSource> Images
            {
                get
                {
                    return _images;
                }
                set
                {
                    if (_images != value)
                    {
                        _images = value;
                        OnPropertyChanged(nameof(Images));
                    }
                }
            }
        }
    }
