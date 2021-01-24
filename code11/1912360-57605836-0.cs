    public class Music : IComparable<Music>, INotifyPropertyChanged
        {
            ......
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            public bool IsPlaying {
    
                set { 
                    IsMusicPlaying = value;
                    OnPropertyChanged();
                }
                get {
                    return IsMusicPlaying;
                }
            }
    
            public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                // Raise the PropertyChanged event, passing the name of the property whose value has changed.
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
