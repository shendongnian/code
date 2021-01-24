        private void TextBox_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (Window.Current.CoreWindow.GetKeyState(VirtualKey.Control).HasFlag(CoreVirtualKeyStates.Down)&& e.Key == Windows.System.VirtualKey.Enter)
            {
                e.Handled = false;
            }
        }
