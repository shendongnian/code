    <TextBox x:Name="txtFeedback" HorizontalAlignment="Left" Height="213" Margin="10,196,0,0" TextWrapping="Wrap" Text="{Binding Path=FeedbackText}" VerticalAlignment="Top" Width="772" Enabled="{Binding Path=IsEnabled}" AcceptsReturn="True"/>
    public bool IsEnabled
    {
        get
        {
            return _isEnabled;
        }
        set
        {
            _isEnabled= value;
            OnPropertyChanged("IsEnabled");
        }
    }
