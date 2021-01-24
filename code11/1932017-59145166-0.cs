public class Startup
{
   public void Configuration(IAppBuilder app)
   {
      app.UseCors(CorsOptions.AllowAll);
      app.MapSignalR();
   }
}
public class SettingHub : Hub
{
   public static void BroadcastData()
   {
      IHubContext context = GlobalHost.ConnectionManager.GetHubContext<SettingHub>();
      context.Clients.All.updatedData();
   }
}
$(function () {
  var notificationFromHub = $.connection.settingHub;
  notificationFromHub.client.updatedData = function () {
     FetchSettings();
     };
  });
  $.connection.hub.start().done(function () {
     FetchSettings();
  });
