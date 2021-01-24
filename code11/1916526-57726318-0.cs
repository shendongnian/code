Text={Binding Content}
###in ViewModel
    public class JobViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string content;
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                if (content != value)
                {
                    content = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private JobModel Model { get; set; }
        public bool IsActive =>
            Model?.IsActive ?? false;
        public bool IsDone =>
            Model?.IsDone ?? false;
        public JobViewModel()
        {
            if (!Model.IsActive)
            {
                Content = "Status:Notactive";
            }
            if (Model.IsDone)
            {
                Content = "Status:Closed";
            }
            Content = "Status:Open";
        }
    }
