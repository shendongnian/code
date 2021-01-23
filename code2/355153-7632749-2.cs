    public class MyListBox : ListBox 
    {
       public static readonly DependencyProperty ConnectorStyleProperty = DependencyProperty.Register(
            "ConnectorStyle", typeof(Style), typeof(MyListBox), null);
        public Style ConnectorStyle
        {
            get { return (Style)GetValue(ConnectorStyleProperty); }
            set { SetValue(ConnectorStyleProperty, value); }
        }
    
    }
