    public class ViewAViewModel : BindableBase
    {
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value, () => RaisePropertyChanged(nameof(FullName));
        }
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value, () => RaisePropertyChanged(nameof(FullName));
        }
        public string FullName => $"{FirstName} {LastName}";
    }
