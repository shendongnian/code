        private void PasswordBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            UpdateCapsLockWarning(e.KeyboardDevice);
        }
        private void PasswordBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            UpdateCapsLockWarning(e.KeyboardDevice);
        }
        private void PasswordBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            CapsLockWarning.Visibility = Visibility.Hidden;
        }
        private void UpdateCapsLockWarning(KeyboardDevice keyboard)
        {
            CapsLockWarning.Visibility = keyboard.IsKeyToggled(Key.CapsLock) ? Visibility.Visible : Visibility.Hidden;
        }
