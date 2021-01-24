<Window x:Class="ExampleApp.ServerView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        Title="ServerView" Height="450" Width="800">
    <Grid>
        <ListView ItemsSource="{Binding Servers}" >
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Border Padding="5">
                        <StackPanel>
                            <TextBlock Text="{Binding CountryName, StringFormat='Country: {0}'}"  />
                            <TextBlock Text="{Binding CityDns, StringFormat='DNS: {0}'}" />
                        </StackPanel>
                    </Border>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
        <Button Content="Refresh" Click="BtnRefresh_Click" HorizontalAlignment="Right" VerticalAlignment="Bottom" Margin="10" Padding="10"/>
    </Grid>
</Window>
Window code behind code:
using System.Windows;
namespace ExampleApp
{
    public partial class ServerView : Window
    {
        private readonly ServerViewModel _model;
        public ServerView()
        {
            InitializeComponent();
            _model = new ServerViewModel();
            DataContext = _model;
        }
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            _model.ReloadServers();
        }
    }
}
ViewModel and Server class code:
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace ExampleApp
{
    public class ServerViewModel
    {
        public ObservableCollection<Server> Servers { get; set; } = new ObservableCollection<Server>();
        public void ReloadServers()
        {
            var servers = DownloadServers();
            Servers.Clear();
            foreach (var server in servers)
            {
                Servers.Add(server);
            }
        }
        private List<Server> DownloadServers()
        {
            //pretend we're downloading the list of servers here...
            return new List<Server>
            {
                new Server { CityDns = "Some DNS", CountryName = "England" },
                new Server { CityDns = "Some other DNS", CountryName = "China" },
                new Server { CityDns = "Another DNS", CountryName = "United States" }
            };
        }
    }
    public class Server
    {
        public string CountryName { get; set; }
        public string CityDns { get; set; }
    }
}
Note that I'm not using an `ICommand` for the refresh button click, I would normally do that.
