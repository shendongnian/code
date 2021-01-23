    public class MyTextBox : TextBox
    {
         System.Text.RegularExpressions.Regex regex = newSystem.Text.RegularExpressions.Regex("[^0-9.-]+"); 
         protected override void OnPreviewTextInput(TextCompositionEventArgs e)
         {
            e.Handled = !regex.IsMatch(e.Text);
         }
    }
