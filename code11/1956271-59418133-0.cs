    public class Lamp : NotifyChange {  //NotifyChange is the INotifyPropertyChanged implementation in a base class
        private _Name;
        public Name{
            get{ return _Name; }
            set{ 
                if( _Name != value ) {
                    _Name = value;
                    OnPropertyChanged( nameof( Name ) );
                }
            }
        }
    }
