    public class CustomTextBox : TextBox
    {
      protected override void OnGotFocus (System.Windows.RoutedEventArgs e)
      {
        if (Keyboard.PrimaryDevice.IsKeyDown(Key.Tab))
        {
          // Do something when Tab is pressed
        }
      }
    }
