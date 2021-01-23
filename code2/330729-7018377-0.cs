    public class MyTextBox : TextBox
    {
         System.Text.RegularExpressions.Regex regex = newSystem.Text.RegularExpressions.Regex("[^0-9.-]+"); 
         protected override void TextChangednPreviewTextInput(TextCompositionEventArgs e)
         {
            IsTextAllowed(e.ControlText);
         }
         private static bool IsTextAllowed(string text)
         {   
           return !regex.IsMatch(text);
         }
    }
