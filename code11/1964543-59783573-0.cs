      private YOURTYPE mySelectedItem;
      public YOURTYPE MySelectedItem
            {
                get => mySelectedItem;
                set
                {
                    mySelectedItem= value;
                    OnPropertyChanged("MySelectedItem");
                }
            }
