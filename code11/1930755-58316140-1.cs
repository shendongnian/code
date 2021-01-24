private void Button1_Click(object sender, RoutedEventArgs e)
{
    char c = ReturnCharacter();
    if (c == 'x')
    {
        button1.Foreground = new SolidColorBrush(Color.FromArgb(255, 51, 178, 255));
    }
    else
    {
        button1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 104, 51));
    }
    button1.Content = c;
}
or more simply and efficiently:
SolidColorBrush blue = new SolidColorBrush(Color.FromArgb(255, 51, 178, 255));
SolidColorBrush red = new SolidColorBrush(Color.FromArgb(255, 255, 104, 51))
private void Button1_Click(object sender, RoutedEventArgs e)
{
    char c = ReturnCharacter();
    button1.Foreground = c == 'x' ? blue : red;
    button1.Content = c;
}
