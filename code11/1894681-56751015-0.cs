    using System.ComponentModel;
    class myClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void  RaisePropertyChanged(
                [System.Runtime.CompilerServices.CallerMemberName]
                string callee = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callee));
        }
    }
