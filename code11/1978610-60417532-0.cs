C#
public async void OnClickPublish()
{
  Loader loader = new Loader();
  loader.Show();
  PublishSlides(loader);
}
private async Task PublishSlides(Loader loader)
{
  loader.LoaderMessage("Opration 1 start..");
  List<SlideProperties> DBList = await Task.Run(() => objSlideImg.DBOpration());
  try
  {
    await SendToCloudAsync(DBList);
    loader.ShowSuccess("broadcasting..");
  }
  catch (Exception ex)
  {
    loader.LoaderMessage(ex.Message + " problem occur in cloud publish");
  } 
  DashboardUI dashboard = new DashboardUI();
  dashboard.ShowDashboard();
}
public async Task<bool> SendToCloudAsync(List<SlideProperties> DBList)
{
  ...
}
