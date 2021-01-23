        public ImageSource MovieImageSource
        {
            get { return mMovieImageSource; }
            // Set property sets the property and implements INotifyPropertyChanged
            set { SetProperty("MovieImageSource", ref mMovieImageSource, value); }
        }
    
       void SetMovieSource(string path)
       {
            myImage = new BitmapImage();
            myImage.BeginInit();
            myImage.UriSource = new Uri(path);
            myImage.EndInit();
            this.MovieImageSource = myImage;
       }
       
