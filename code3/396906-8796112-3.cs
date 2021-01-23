    <StackPanel>
        <StackPanel x:Name="upperPanel" FocusManager.IsFocusScope="True" GotFocus="upperPanel_GotFocus">
            <TextBox x:Name="TextBox1"></TextBox>
            <TextBox x:Name="TextBox2"></TextBox>
        </StackPanel>
        <StackPanel>
            <ListBox x:Name="ListBox1" SelectionChanged="ListBox_SelectionChanged">
                <ListBoxItem>First</ListBoxItem>
                <ListBoxItem>Second</ListBoxItem>
                <ListBoxItem>Third</ListBoxItem>
            </ListBox>
            <ListBox x:Name="ListBox2" SelectionChanged="ListBox_SelectionChanged">
                <ListBoxItem>4</ListBoxItem>
                <ListBoxItem>5</ListBoxItem>
                <ListBoxItem>6</ListBoxItem>
            </ListBox>
        </StackPanel>
    </StackPanel>
    private IInputElement focusedElement = null;
    private void upperPanel_GotFocus(object sender, RoutedEventArgs e)
    {
        focusedElement = e.Source as IInputElement;
    }
    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateTextBoxValue((e.AddedItems[0] as ListBoxItem).Content.ToString());
    }
    private void UpdateTextBoxValue(string text)
    {
        TextBox focusedTextBox = focusedElement as TextBox;
        if (focusedTextBox != null)
        {
            focusedTextBox.Text = text;
        }
        upperPanel.Focus();
    }
