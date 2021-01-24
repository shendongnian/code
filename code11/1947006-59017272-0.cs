    class ComboBox : DependencyObject
    {
      #region IsFilterOnAutoCompleteEnabled attached property
      public static readonly DependencyProperty IsFilterOnAutocompleteEnabledProperty =
        DependencyProperty.RegisterAttached(
          "IsFilterOnAutocompleteEnabled",
          typeof(bool),
          typeof(ComboBox),
          new PropertyMetadata(default(bool), ComboBox.OnIsFilterOnAutocompleteEnabledChanged));
      public static void SetIsFilterOnAutocompleteEnabled(DependencyObject attachingElement, bool value) =>
        attachingElement.SetValue(ComboBox.IsFilterOnAutocompleteEnabledProperty, value);
      public static bool GetIsFilterOnAutocompleteEnabled(DependencyObject attachingElement) =>
        (bool) attachingElement.GetValue(ComboBox.IsFilterOnAutocompleteEnabledProperty);
      #endregion
      private static Dictionary<TextBox, System.Windows.Controls.ComboBox> TextBoxComboBoxMap { get; set; }
      static ComboBox() => ComboBox.TextBoxComboBoxMap = new Dictionary<TextBox, System.Windows.Controls.ComboBox>();
      private static void OnIsFilterOnAutocompleteEnabledChanged(
        DependencyObject attachingElement,
        DependencyPropertyChangedEventArgs e)
      {
        if (!(attachingElement is System.Windows.Controls.ComboBox comboBox 
          && comboBox.IsEditable))
        {
          return;
        }
        if (!(bool) e.NewValue)
        {
          ComboBox.DisableAutocompleteFilter(comboBox);
          return;
        }
       
        if (!comboBox.IsLoaded)
        {
          comboBox.Loaded += ComboBox.EnableAutocompleteFilterOnComboBoxLoaded;
          return;
        }
        ComboBox.EnableAutocompleteFilter(comboBox);      
      }
    
      private static async void FilterOnTextInput(object sender, TextChangedEventArgs e)
      {
        await Application.Current.Dispatcher.InvokeAsync(
          () =>
          {
            var textBox = sender as TextBox;
            string changedTextOnAutocomplete = textBox.Text.Substring(0, textBox.SelectionStart);
            if (ComboBox.TextBoxComboBoxMap.TryGetValue(
              textBox,
              out System.Windows.Controls.ComboBox comboBox))
            {
              comboBox.Items.Filter = item => item.ToString().StartsWith(
                changedTextOnAutocomplete,
                StringComparison.OrdinalIgnoreCase);
            }
          },
          DispatcherPriority.Normal);
      }
      private static void EnableAutocompleteFilterOnComboBoxLoaded(object sender, RoutedEventArgs e)
      {
        var comboBox = sender as System.Windows.Controls.ComboBox;
        ComboBox.EnableAutocompleteFilter(comboBox);
      }
      private static void EnableAutocompleteFilter(System.Windows.Controls.ComboBox comboBox)
      {
        if (comboBox.TryFindVisualChildElement(out TextBox editTextBox))
        {
          ComboBox.TextBoxComboBoxMap.Add(editTextBox, comboBox);
          editTextBox.TextChanged += ComboBox.FilterOnTextInput;
        }
      }
      private static void DisableAutocompleteFilter(System.Windows.Controls.ComboBox comboBox)
      {
        if (comboBox.TryFindVisualChildElement(out TextBox editTextBox))
        {
          ComboBox.TextBoxComboBoxMap.Remove(editTextBox);
          editTextBox.TextChanged -= ComboBox.FilterOnTextInput;
        }
      }
    }
