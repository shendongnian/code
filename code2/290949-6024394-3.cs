    namespace Sample.ViewModels
    {
        public class ConnectedSystemViewModel : PropertyChangedBase
        {
            private string _propertyOne;
            public string PropertyOne
            {
                get { return _propertyOne; }
                set
                {
                    _propertyOne = value;
                    NotifyOfPropertyChange(() => PropertyOne);
                }
            }
    
            // these all need to be as above with NotifyPropertyChange,
            // omitted for brevity.
            public string PropertyTwo { get; set;}
            public string PropertyThree { get; set;}
            public string PropertyFour { get; set;}
            public string PropertyFive { get; set;}
            public string PropertySix { get; set;}
            public string PropertySeven { get; set;}
            public string PropertyEight { get; set;}
            public string PropertyNine { get; set;}
            public string PropertyTen { get; set;}
        }
    }
