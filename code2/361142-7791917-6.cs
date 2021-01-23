    public class ComboBoxSelectionBehavior:Behavior<ComboBox>
    {
      protected override void OnAttached()
      {
        base.OnAttached();
        AssociatedObject.Loaded += ComboBoxLoaded;
      }
    
      protected override void OnDetaching()
      {
        AssociatedObject.Loaded -= ComboBoxLoaded;
        base.OnDetaching();
      }
    
      private void ComboBoxLoaded(object sender, RoutedEventArgs e)
      {
        if(Count > 1)
        {
          SelectedIndex = 1;
        }
      }
    }
