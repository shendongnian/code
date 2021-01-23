    public static readonly DependencyProperty TheItemProperty=
        DependencyProperty.Register("TheItem", typeof(string), typeof(OrderEditorViewModel), 
            new PropertyMetadata((s, e) => {
                switch (e.NewValue) {
                    case "SomeValue":
                        // Do something
                        break;
                    case "SomeOtherValue":
                        // Do another thing
                        break;
                    default:
                        // Some default action
                        break;
                 }
         }));
    
    public string TheItem{
      get { return (string)GetValue(TheItemProperty); }
      set { SetValue(TheItemProperty, value); }
    }
