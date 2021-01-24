    public class TextTrimBehavior : DependencyObject
    {
      #region IsEnabled attached property
    
      public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached(
        "IsEnabled", typeof(bool), typeof(TextTrimBehavior), new PropertyMetadata(false, TextTrimBehavior.OnAttached));
    
      public static void SetIsEnabled(DependencyObject attachingElement, bool value)
      {
        attachingElement.SetValue(TextTrimBehavior.IsEnabledProperty, value);
      }
    
      public static bool GetIsEnabled(DependencyObject attachingElement)
      {
        return (bool) attachingElement.GetValue(TextTrimBehavior.IsEnabledProperty);
      }
    
      #endregion
    
      private static void OnAttached(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
        if (!(d is TextBox attachedTextBox))
        {
          return;
        }
    
        if ((bool) e.NewValue)
        {
          attachedTextBox.LostFocus += TextTrimBehavior.TrimText;
        }
        else
        {
          attachedTextBox.LostFocus -= TextTrimBehavior.TrimText;
        }
      }
    
      private static void TrimText(object sender, RoutedEventArgs e)
      {
        if (sender is TextBox textBox)
        {
          textBox.Text = textBox.Text.Trim();
        }
      }
    }
