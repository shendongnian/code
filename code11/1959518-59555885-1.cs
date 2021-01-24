        public class MainWindowViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            internal void SelectedAnswerChanged()
            {
                RaisePropertyChanged(nameof(SelectedAnswer));
            }
    
            public Order Order { get; set; }
            public Answer SelectedAnswer
            {
                get { return Order.Questions.First().Answers.FirstOrDefault(x => x.IsSelected); }
            }
        }
