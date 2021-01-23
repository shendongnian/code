            public Person Person
        {
            get
            {
                return this.person;
            }
            set
            {
                if (!this.person.Equals(value))
                {
                    this.person = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Person"));
                }
            }
        }
