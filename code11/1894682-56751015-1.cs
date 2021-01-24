    using System.ComponentModel;
    class myClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void  RaisePropertyChanged(
                [System.Runtime.CompilerServices.CallerMemberName]
                string callee = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callee));
        }
        private object myField;
        public object MyProperty {
            get { return myField; }
            set
            {
                myField= value;
                RaisePropertyChanged();
            }
    }
