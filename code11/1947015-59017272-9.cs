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
        (bool)attachingElement.GetValue(ComboBox.IsFilterOnAutocompleteEnabledProperty);
      #endregion
      private static Dictionary<TextBox, System.Windows.Controls.ComboBox> TextBoxComboBoxMap { get; }
      private static Dictionary<TextBox, int> TextBoxSelectionStartMap { get; }
      private static Dictionary<System.Windows.Controls.ComboBox, TextBox> ComboBoxTextBoxMap { get; }
      private static bool IsNavigationKeyPressed { get; set; }
      static ComboBox()
      {
        ComboBox.TextBoxComboBoxMap = new Dictionary<TextBox, System.Windows.Controls.ComboBox>();
        ComboBox.TextBoxSelectionStartMap = new Dictionary<TextBox, int>();
        ComboBox.ComboBoxTextBoxMap = new Dictionary<System.Windows.Controls.ComboBox, TextBox>();
      }
      private static void OnIsFilterOnAutocompleteEnabledChanged(
        DependencyObject attachingElement,
        DependencyPropertyChangedEventArgs e)
      {
        if (!(attachingElement is System.Windows.Controls.ComboBox comboBox
          && comboBox.IsEditable))
        {
          return;
        }
        if (!(bool)e.NewValue)
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
            if (ComboBox.IsNavigationKeyPressed)
            {
              return;
            }
            var textBox = sender as TextBox;
            int textBoxSelectionStart = textBox.SelectionStart;
            ComboBox.TextBoxSelectionStartMap[textBox] = textBoxSelectionStart;
            string changedTextOnAutocomplete = textBox.Text.Substring(0, textBoxSelectionStart);
            if (ComboBox.TextBoxComboBoxMap.TryGetValue(
              textBox,
              out System.Windows.Controls.ComboBox comboBox))
            {
              comboBox.Items.Filter = item => item.ToString().StartsWith(
                changedTextOnAutocomplete,
                StringComparison.OrdinalIgnoreCase);
            }
          },
          DispatcherPriority.Background);
      }
      private static async void HandleKeyDownWhileFiltering(object sender, KeyEventArgs e)
      {
        var comboBox = sender as System.Windows.Controls.ComboBox;
        if (!ComboBox.ComboBoxTextBoxMap.TryGetValue(comboBox, out TextBox textBox))
        {
          return;
        }
        switch (e.Key)
        {
          case Key.Down 
            when comboBox.Items.CurrentPosition < comboBox.Items.Count - 1 
                 && comboBox.Items.MoveCurrentToNext():
          case Key.Up 
            when comboBox.Items.CurrentPosition > 0 
                 && comboBox.Items.MoveCurrentToPrevious():
          {
            // Prevent the filter from re-apply as this would override the
            // current selection start index
            ComboBox.IsNavigationKeyPressed = true;
            // Ensure the Dispatcher en-queued delegate 
            // (and the invocation of the SelectCurrentItem() method)
            // executes AFTER the FilterOnTextInput() event handler.
            // This is because key input events have a higher priority
            // than text change events by default. The goal is to make the filtering 
            // triggered by the TextBox.TextChanged event ignore the changes 
            // introduced by this KeyDown handler.
            // DispatcherPriority.ContextIdle will force to "override" this behavior.
            await Application.Current.Dispatcher.InvokeAsync(
              () =>
              {
                ComboBox.SelectCurrentItem(textBox, comboBox);
                ComboBox.IsNavigationKeyPressed = false;
              }, 
              DispatcherPriority.ContextIdle);
            
            break;
          }
        }
      }
      private static void SelectCurrentItem(TextBox textBox, System.Windows.Controls.ComboBox comboBox)
      {
        comboBox.SelectedItem = comboBox.Items.CurrentItem;
        if (ComboBox.TextBoxSelectionStartMap.TryGetValue(textBox, out int selectionStart))
        {
          textBox.SelectionStart = selectionStart;
        }
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
          ComboBox.ComboBoxTextBoxMap.Add(comboBox, editTextBox);
          editTextBox.TextChanged += ComboBox.FilterOnTextInput;
          // Need to receive handled KeyDown event
          comboBox.AddHandler(UIElement.PreviewKeyDownEvent, new KeyEventHandler(HandleKeyDownWhileFiltering), true);
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
