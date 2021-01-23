    public class MyComboBox : ComboBox
    {
      public MyComboBox
      {
        Loaded += ComboBoxLoaded;
      }
      
      private void ComboBoxLoaded(object sender, RoutedEventArgs e)
      {
        if(Count > 1)
        {
          SelectedIndex = 1;
        }
      }
    }
