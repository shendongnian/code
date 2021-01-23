    public class MyPicture : INotifyPropertyChanged
    {
        private string url;
        private string name;
        // Other fields
       public Url
       {
                get{ return value;}
                set{url=value;}
                OnPropertyChanged("Url")
       }
    }
        //Do same for other fields . I leave the implementation if INPC on you
