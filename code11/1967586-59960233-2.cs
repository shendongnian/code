csharp
protected override async void OnResume()
{
    base.OnResume();
    try
    {
        MakeWebRequest();
        if (IsConnected != true)
        {
             MainPage = new NoInternet();
        }
        else
        {
            await MainPage.Navigation.PopToRootAsync(true);
            await MainPage.Navigation.PushAsync(new Home("XXXX"));
        }
    }
    catch (IOException ex)
    {
        Crashes.TrackError(ex);
    }
}
