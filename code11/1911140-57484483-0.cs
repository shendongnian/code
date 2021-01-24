        public RegistrarPatron ()
        {
            InitializeComponent ();
            GetOficinas().Wait();
        }
You should almost never Wait() on a Task like this: it will freeze your app or block a thread forever.
Do this instead:
namespace PlaqueoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarPatron : ContentPage
    {
        public RegistrarPatron ()
        {
            InitializeComponent ();
        }
 
        protected override async void OnAppearing()
        {
            try 
            {
                await GetOficinas();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(e.ToString());
            }   
        }
        private async Task GetOficinas()
        {
            Ping myPing = new Ping();
            PingReply reply = myPing.Send("8.8.8.8", 10000);
            HttpClient cliente = new HttpClient();
            string url = "https://reqres.in/api/users?page=2";
            var response = await cliente.GetStringAsync(url);
            var anonimus = JsonConvert.DeserializeObject<List<object>>(response);
        }
    }
}
