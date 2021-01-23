    <StackPanel>
        <StackPanel x:Name="upperPanel" FocusManager.IsFocusScope="True">
            <TextBox x:Name="TextBox1"></TextBox>
            <TextBox x:Name="TextBox2"></TextBox>
        </StackPanel>
        <Grid>
            <ListBox x:Name="ListBox1" SelectionChanged="ListBox_SelectionChanged">
                <ListBoxItem>First</ListBoxItem>
                <ListBoxItem>Second</ListBoxItem>
                <ListBoxItem>Third</ListBoxItem>
            </ListBox>
        </Grid>
    </StackPanel>
    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Get the focused element in the focus group.
        var focusedElement = FocusManager.GetFocusedElement(upperPanel);
        // If it's a TextBox, set its value.
        TextBox focusedTextBox = focusedElement as TextBox;
        if (focusedTextBox != null)
        {
            focusedTextBox.Text = (e.AddedItems[0] as ListBoxItem).Content.ToString();
        }
        // Set focus back to the focused item in the upper panel.
        // Could also use focusedElement.Focus();
        upperPanel.Focus();
    }
