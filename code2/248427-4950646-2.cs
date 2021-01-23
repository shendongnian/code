    public ObservableCollection<MyEntity> MyCollection
    {
        get;
        private set;
    }
    private void CustCntr_Loaded(object sender, RoutedEventArgs e)
    {
        CustCntr custCntr = sender as CustCntr ;
        foreach (MyEntity myEntity in MyCollection)
        {
            if (custCntr.Name == myEntity.Name)
            {
                Binding property1Binding = new Binding("Property1");
                property1Binding.Source = myEntity;
                property1Binding.Mode = BindingMode.TwoWay;
                custCntr.SetBinding(CustCntr.Property1Property, property1Binding);
                break;
            }
        }
    }
