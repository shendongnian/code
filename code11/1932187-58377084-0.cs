public interface IHTTPClientHandlerCreationService
{
  HttpClientHandler GetInsecureHandler();
}
###in Android implemented the interface:
[assembly: Dependency(typeof(HTTPClientHandlerCreationService_Android))]
namespace xxx.Droid
{
  public class HTTPClientHandlerCreationService_Android : CollateralUploader.Services.IHTTPClientHandlerCreationService
  {
    public HttpClientHandler GetInsecureHandler()
    {
      return new IgnoreSSLClientHandler();
    }
  }
  internal class IgnoreSSLClientHandler : AndroidClientHandler
  {
    protected override SSLSocketFactory ConfigureCustomSSLSocketFactory(HttpsURLConnection connection)
    {
      return SSLCertificateSocketFactory.GetInsecure(1000, null);
    }
    protected override IHostnameVerifier GetSSLHostnameVerifier(HttpsURLConnection connection)
    {
      return new IgnoreSSLHostnameVerifier();
    }
  }
  internal class IgnoreSSLHostnameVerifier : Java.Lang.Object, IHostnameVerifier
  {
    public bool Verify(string hostname, ISSLSession session)
    {
      return true;
    }
  }
}
And when you call the method `Get`
public async void BindToListView()
{
  HttpClient client;
  switch (Device.RuntimePlatform)
  {
    case Device.Android:
      this.httpClient = new HttpClient(DependencyService.Get<Services.IHTTPClientHandlerCreationService>().GetInsecureHandler());
      break;
    default:
      ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
      this.httpClient = new HttpClient(new HttpClientHandler());
      break;
  }
  var response = await client.GetStringAsync("https://10.0.2.2:#####/api/Values");
  var posts = JsonConvert.DeserializeObject<ObservableCollection<Posts>>(response);
  lv.ItemsSource = posts;
}
In addition, I suggest that you can use `ObservableCollection` instead of `List` because it has implemented the interface **INotifyPropertyChanged** . Otherwise the UI will never been updated .
