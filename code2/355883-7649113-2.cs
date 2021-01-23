    public class PluginViewModel : ViewModel
    {
        public string Name { get; }
        public PluginState State { get; private set; }
        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand RestartCommand { get; }
    }
    
    public class PluginLauncherViewModel : ViewModel
    {
        // use an ObservableCollection<PluginViewModel> to store your plugin view models
        public ICollection<PluginViewModel> Plugins { get; }
    }
    
    <ScrollViewer>
        <ItemsControl ItemsSource="{Binding Plugins}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                     <UniformGrid Rows="1">
                         <TextBlock Text="{Binding Name}"/>
                         <TextBlock Text="{Binding Status}"/>
                         <Button Command="{Binding StartCommand}">Start</Button>
                         <Button Command="{Binding StopCommand}">Stop</Button>
                         <Button Command="{Binding RestartCommand}">Restart</Button>
                     </UniformGrid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </ScrollViewer>
