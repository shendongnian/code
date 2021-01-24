private bool DefaultClicked;
private void OnDefaultClicked(object sender, RoutedEventArgs e)
{
    DefaultButton.IsEnabled = false;
    DefaultClicked = true;
    displayedData = defaultData;
    //rest of method code
}
private void OnTextChanged(object sender, RoutedEventArgs e)
{
    if(!DefaultClicked)
    {
        DefaultButton.IsEnabled = true;
    }
    DefaultClicked = false;
    //rest of method code
}
