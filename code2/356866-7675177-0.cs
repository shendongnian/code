    public class PersonViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private Person _person;
        [Required] //This seems redundent...
        public ValueViewModel<String> FirstName { ... }
    }
