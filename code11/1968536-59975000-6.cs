    <UniformGrid Columns="1">
        <Button x:Name="AddStar" Content="Add star to text" Click="AddStar_Click" />
        <TextBlock x:Name="Dots" Text="." Margin="20 0" VerticalAlignment="Center" FontSize="24" />
    </UniformGrid>
    public MainWindow()
    {
        InitializeComponent();
        PrintDots();
    }
    public async void PrintDots()
    {
        // This will run forever, printing a dot every 0.2 seconds, clearing the string, when it reaches 50 characters.
        while (true)
        {
            _sb.Append(".");
            await Task.Delay(200);
            if (_sb.Length == 50) { _sb.Clear(); }
            Dots.Text = _sb.ToString();
        }
    }
    private void AddStar_Click(object sender, RoutedEventArgs e)
    {
        // On click a star (asterix) will be appended to the string
        _sb.Append("*");
        Dots.Text = _sb.ToString();
    }
