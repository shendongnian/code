     private ObservableCollection<Card> _combodata;
    
            public ObservableCollection<Card> comboData
            {
                get
                {
                    if (_combodata == null)
                        _combodata = new ObservableCollection<Card>();
                    return _combodata;
                }
                set
                {
                    if (value != _combodata)
                        _combodata = value;
                }
            }
    
      if (_objCardField.FieldTag == "State") 
                    {
                        cards = new Cards();
                        foreach (var item in App.db.States)
                        {
                            Card c = new Card(item.StateName, item.StateID);
                            comboData.Add(c);
                        }
                    }
