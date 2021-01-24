    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
                // insert your message to database
                collec.InsertOne(new Message 
                {
                    Sent = DateTime.Now,
                    Msg = message
                });
                await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
public void ConfigureServices(IServiceCollection services)
{
     services.AddRazorPages();
     services.AddSignalR();
}
 public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
 {
      //some code here
      app.UseEndpoints(endpoints =>
      {
          endpoints.MapRazorPages();
         endpoints.MapHub<ChatHub>("/chatHub");
      });
}
  [1]: https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-3.1&tabs=visual-studio
