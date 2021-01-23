        private void ClearCommandBindingCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // e.Source is the element that is active,
            if (e.Source is TextBox) // and whatever other logic you need.
            {
                e.CanExecute = true;
                e.Handled = true;
            }
        }
        private void ClearCommandBindingExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var textBox = e.Source as TextBox;
            if (textBox != null)
            {
                textBox.Clear();
                e.Handled = true;
            } 
        }
