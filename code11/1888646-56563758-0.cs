        <Grid x:Name="Video" Grid.Row="1" Grid.Column="1">
            <Frame x:Name="MainContentRegion" Margin="5" Content="{Binding CurrentPage}"/>
        </Grid>
Then all you have to do in your ViewModel is have a CurrentPage variable that was binded to in the xaml View. And change what view that points to.
(ShellPageViewModel.cs)
        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                RaisePropertyChanged();
            }
        }
        public void GoToSettingsPage()
        {
            CurrentPage = new SettingsView();
        }
I use commands with other navigation buttons on the shell page to trigger this command. If you have any other questions on how to use this method, let me know!
