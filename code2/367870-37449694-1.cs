    public class Vehicle : ObjectBase
    {
 
      int _CarId;
    
     public int CarId
            {
                get { return _CarId; }
                set
                {
                    if (_CarId != value)
                    {
                        _CarId = value;
                        OnPropertyChanged(nameof(CarId));
                    }
    
                }
            }
      }
