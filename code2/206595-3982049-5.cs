    void ListBoxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if ((Keyboard.Modifiers & ModifierKeys.Control) > 0)
        {
            Console.WriteLine((sender as ListBoxItem).Content.ToString());
            e.Handled = false;
        }
    }
