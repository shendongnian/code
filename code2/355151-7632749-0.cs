    public class MyListBox : ListBox 
    {
       public static DependencyProperty ConnectorStyleProperty =
           DependencyProperty.Register("ConnectorStyle", typeof(Style), 
                                       typeof(NodePicture), null);
    
      public NodePicture ConnectorStyle   
      {
         get {return (NodePicture)GetValue(ConnectorStyleProperty); }
         set { SetValue(ConnectorStyleProperty, value); }    
      }
    
    }
