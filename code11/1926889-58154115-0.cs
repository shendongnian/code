    public class Seat : INotifyPropertyChanged
        {
            private int seatNo;
            private string seatNumber;
            private bool isSelected;
    
            public int SeatNo
            {
                get { return seatNo; }
                set { seatNo = value; OnPropertyChanged(); }
            }
    
            public string SeatNumber
            {
                get { return seatNumber; }
                set { seatNumber = value; OnPropertyChanged(); }
            }
    
            public bool IsSelected
            {
                get { return isSelected; }
                set { isSelected = value; OnPropertyChanged(); }
            }
    
            public void OnPropertyChanged([CallerMemberName]string popertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(popertyName));
            }
    
            private void BaseVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
