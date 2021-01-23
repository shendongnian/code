    private Collection<string> sources = new Collection<string>() { "ABC", "DEF", "XYZ" };
    public Collection<string> Sources { get { return sources; } }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        myObjectCollection[0].SelectedType = Sources[0];
        myObjectCollection[1].SelectedType = Sources[2];
    }
