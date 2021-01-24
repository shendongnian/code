    private void TimesheetDataGrid_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.OemPeriod)
        {
            e.Handled = true;
            Keyboard.FocusedElement.RaiseEvent(
              new TextCompositionEventArgs(InputManager.Current.PrimaryKeyboardDevice,
                new TextComposition(InputManager.Current, Keyboard.FocusedElement, ","))
              { RoutedEvent = TextCompositionManager.TextInputEvent }
            );
        }
    }
