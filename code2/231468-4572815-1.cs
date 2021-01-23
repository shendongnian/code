    <RadioButton Group="BooleanProperty1" IsChecked="{Binding BooleanProperty1, Mode=TwoWay}"/>
    <RadioButton Group="BooleanProperty2" IsChecked="{Binding BooleanProperty2, Mode=TwoWay}"/>
    <RadioButton Group="BooleanProperty3" IsChecked="{Binding BooleanProperty3, Mode=TwoWay}"/>
    public bool BooleanProperty1
    {
       set
       {
          if (value != _BooleanProperty1)
          {
             _BooleanProperty1 = value;
             if (value)
             {
                BooleanProperty2 = false;
                BooleanProperty3 = false;
             }
             OnPropertyChanged("BooleanProperty1");
           }
       }
    }
