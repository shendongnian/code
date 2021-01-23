private void button1_click(object sender, RoutedEventArgs e)
{
    Button source = (Button)sender;
    Image content = source.Content as Image;
    if (null != content)
    {
        content.Source = new BitmapImage(new Uri("image path"));
    }
}
