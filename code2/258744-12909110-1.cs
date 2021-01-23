      private IndividualName _name;
    public IndividualName PersonName
            {
                get { return _name; }
                set { SetField(ref _name, value, () => PersonName); }
            }
  
