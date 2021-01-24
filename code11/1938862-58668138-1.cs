    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    namespace ImagePickerDropdownSample
    {
        public partial class ImagePickerDropdown : ContentView
        {
            public ImagePickerDropdown()
            {
                InitializeComponent();
            }
            private void ImageSelected(object sender, EventArgs e)
            {
                var imageSource = (sender as ImageButton).Source;
                SelectedImage = imageSource;
                mainButton.IsEnabled = true;
                stackView.IsVisible = false;
            }
            private void ImageClicked(object sender, EventArgs e)
            {
                mainButton.IsEnabled = false;
                stackView.IsVisible = true;
            }
            public static readonly BindableProperty SelectedImageProperty =
      BindableProperty.Create(nameof(SelectedImage), typeof(ImageSource), typeof(ImagePickerDropdown), null);
            public ImageSource SelectedImage
            {
                get
                {
                    return (ImageSource)GetValue(SelectedImageProperty);
                }
                set
                {
                    SetValue(SelectedImageProperty, value);
                }
            }
            public static readonly BindableProperty ImagesProperty =
      BindableProperty.Create(nameof(Images), typeof(ObservableCollection<ImageSource>), typeof(ImagePickerDropdown), null);
            public ObservableCollection<ImageSource> Images
            {
                get
                {
                    return (ObservableCollection<ImageSource>)GetValue(ImagesProperty);
                }
                set
                {
                    SetValue(ImagesProperty, value);
                }
            }
        }
    }
