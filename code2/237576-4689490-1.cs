     // my view model
    public class ValidationTestViewModel : ViewModelBase
    {
        // the property to be validated
        string _name;
        [Required]
        [StartsCapital]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value, () => Name); }
        }
