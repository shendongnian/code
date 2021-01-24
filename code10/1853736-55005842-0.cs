    public GollyAPICotroller()
    {
        client = new HttpClient();
    }
    public static async Task Main()
    {
            try
            {
                string responseBody = await client.GetStringAsync("http://google-auth-express-app.herokuapp.com/api/game?id=600");
                Console.WriteLine(responseBody);
                Console.WriteLine("responseBody");
            }
            catch(HttpRequestException exception)
            {
                Console.WriteLine("Whoops!: {0}", exception.Message);
            }//catch
    }
