    public class TextBox : DependencyObject
    {
      #region IsTextConversionEnabled attached property
      public static readonly DependencyProperty IsTextConversionEnabledProperty = DependencyProperty.RegisterAttached(
        "IsTextConversionEnabled", 
        typeof(bool), 
        typeof(TextBox), 
        new PropertyMetadata(false, TextBox.OnIsTextConversionEnabledChanged));
      public static void SetIsTextConversionEnabled([NotNull] DependencyObject attachingElement, bool value) => attachingElement.SetValue(TextBox.IsTextConversionEnabledProperty, value);
      public static bool GetIsTextConversionEnabled([NotNull] DependencyObject attachingElement) => (bool) attachingElement.GetValue(TextBox.IsTextConversionEnabledProperty);
      #endregion
      #region Converter attached property
      public static readonly DependencyProperty ConverterProperty = DependencyProperty.RegisterAttached(
        "Converter", 
        typeof(IValueConverter), 
        typeof(TextBox), 
        new PropertyMetadata(default(IValueConverter)));
      public static void SetConverter([NotNull] DependencyObject attachingElement, IValueConverter value) => attachingElement.SetValue(TextBox.ConverterProperty, value);
      public static IValueConverter GetConverter([NotNull] DependencyObject attachingElement) => (IValueConverter) attachingElement.GetValue(TextBox.ConverterProperty);
      #endregion
      private static void OnIsTextConversionEnabledChanged(DependencyObject attachingElement, DependencyPropertyChangedEventArgs e)
      {
        if (!(attachingElement is System.Windows.Controls.TextBox textBox))
        {
          return;
        }
        bool isEnabled = (bool) e.NewValue;
        if (isEnabled)
        {
          textBox.LostFocus += TextBox.ConvertTextOnLostFocus;
        }
        else
        {
          textBox.LostFocus -= TextBox.ConvertTextOnLostFocus;
        }
      }
      private static void ConvertTextOnLostFocus(object sender, RoutedEventArgs e)
      {
        var textBox = sender as System.Windows.Controls.TextBox;
        textBox.Text = TextBox.GetConverter(textBox)?.Convert(
          textBox.Text,
          typeof(string),
          string.Empty,
          CultureInfo.CurrentUICulture) as string ?? textBox.Text;
      }
    }
