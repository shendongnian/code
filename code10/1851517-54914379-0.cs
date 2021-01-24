    class Operand : INotifyPropertyChanged
    {
        public bool IsNegated
        {
            get { return m_isNegated; }
            set { m_isNegated = value; RaisePropertyChanged(); }
        }
        private bool m_isNegated = false;
    
        private void RaisePropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
