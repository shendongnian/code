    using System.Collections.ObjectModel;
    using Microsoft.AspNetCore.SignalR.Client;
    public class HubService
    {
        public static HubService Instance { get; } = new HubService();
        public ObservableCollection<string> Notifications { get; set; }
        public async void Initialized()
        {
            this.Notifications = new ObservableCollection<string>();
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(UrlBuilder.BuildEndpoint("Notifications"))
                .Build();
            hubConnection.On<string>("ReciveServerUpdate", update =>
            {
                //todo, adding updates tolist for example
            });
            await hubConnection.StartAsync();
        }
    }
