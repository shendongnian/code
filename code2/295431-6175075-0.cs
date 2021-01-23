    public class PhotoChangedEventArgs : EventArgs
    {
    
    }
    
    public class Student
    {
        public Stream GetPhoto()
        {
            // Implementation.
        }
    
        public event EventHandler<PhotoChangedEventArgs> OnPhotoChanged;
    }
    
    public class StudentViewModel : ViewModelBase
    {
        // INPC has skipped for clarity.
        public Student Model
        {
            get;
            private set;
        }
    
        public BitmapSource Photo
        {
            get
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = Model.Photo;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }
    
        public StudentViewModel(Student student)
        {
            Model = student;
    
            // Set event handler for OnPhotoChanged event.
            Model.OnPhotoChanged += HandlePhotoChange;
        }
    
        void HandlePhotoChange(object sender, PhotoChangedEventArgs e)
        {
            // Force data binding to refresh photo.
            RaisePropertyChanged("Photo");
        }
    }
