    private void RemoveListBoxItem_Click(object sender, RoutedEventArgs e)
    {
        // The clicked Button
        Button button = sender as Button;
        // The DataContext of the Button will be its instance of MyClass
        MyClass selectedItem = button.DataContext as MyClass;
        if (selectedItem != null)
        {
            // Remove the MyClass item from the collection
            MyClasses.Remove(selectedItem);
        }
    }
