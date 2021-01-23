    Person.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Person_PropertyChanged);
    void Person_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if(e.PropertyName == "Name")
        {
             //do something
        }
    }
