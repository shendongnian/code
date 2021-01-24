    public class ThatParticulareClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {  
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // [...] all the other stuff
        public void MethodThatUpdateDataTable()
        {
            // Update DataTable
            NotifyPropertyChanged(nameof(dt));
        }
    }
