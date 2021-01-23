        private void ClearCommandBindingCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // e.Source is the element that is active,
            if (e.Source is TextBox) // and whatever other logic you need.
            {
                e.CanExecute = true;
                e.Handled = true;
            }
        }
