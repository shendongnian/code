    public class TextBoxValidator : Behavior<TextBox>
    {
      protected override void OnAttached()
      {
        AssociatedObject.TextChanged += new TextChanged(OnTextChanged);
      }
    
      private void OnTextChanged(object sender, TextChangedEventArgs e)
      {
        // Here you could add the code shown above by Firedragon or you could
        // just use int.TryParse to see if the number if valid.
        // You could also expose a Regex property on the behavior to allow lots of
        // types of validation
      }
    }
