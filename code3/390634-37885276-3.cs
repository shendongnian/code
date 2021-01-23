    public class MainWindowViewModel : INPCBase
    {
        private string field1;
        private string field2;
        public MainWindowViewModel()
        {
            field1 = "Hello";
            field2 = "World";
            this.ObserveSpecificPropertyChanging(x => x.Field2)
               .Subscribe(x =>
               {
                   if (x.OriginalEventArgs.NewValue == "DOG")
                   {
                       x.OriginalEventArgs.Cancel = true;
                   }
               });
        }
        public string Field1
        {
            get
            {
                return field1;
            }
            set
            {
                if (field1 != value)
                {
                    if (this.OnPropertyChanging("Field1", field1, value))
                    {
                        var previousValue = field1;
                        field1 = value;
                        this.OnPropertyChanged("Field1", previousValue, value);
                    }
                }
            }
        }
        public string Field2
        {
            get
            {
                return field2;
            }
            set
            {
                if (field2 != value)
                {
                    if (this.OnPropertyChanging("Field2", field2, value))
                    {
                        var previousValue = field2;
                        field2 = value;
                        this.OnPropertyChanged("Field2", previousValue, value);
                    }
                }
            }
        }
    }
