c#
private void RadioButton_Checked(object sender, RoutedEventArgs e)
{
    if (MilesButton.IsChecked ?? false)
    {
            radius = 3956;
    }
}
