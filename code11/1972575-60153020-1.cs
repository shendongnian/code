    using System.Windows;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Builder;
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private IHost _host;
            private async void Start_Click(object sender, RoutedEventArgs e)
            {
                _host?.Dispose();
                _host = Host.CreateDefaultBuilder()
                    .ConfigureWebHostDefaults(webBuilder => webBuilder
                        .UseUrls("http://localhost:5100")
                        .ConfigureServices(services => services.AddSignalR())
                        .Configure(app =>
                        {
                            app.UseRouting();
                            app.UseEndpoints(endpoints => endpoints.MapHub<StreamHub>("/streamHub"));
                        }))
                   .Build();
                await _host.StartAsync();
            }
            private async void Stop_Click(object sender, RoutedEventArgs e)
            {
                if (_host != null)
                {
                    await _host.StopAsync();
                    _host.Dispose();
                }
            }
        }
    }
