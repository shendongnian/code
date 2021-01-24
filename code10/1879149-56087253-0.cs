        static void Main()
        {
            Init().Wait();
        }
        public static async Task Init()
        {
            var podio = new Podio(clientId, clientSecret);
            Console.WriteLine("Client ID and Secret");
            //await podio.AuthenticateWithApp(appId, appToken);
            await podio.AuthenticateWithPassword(username, password);
            Console.WriteLine("Authenticated");
            var item = await podio.ItemService.GetItem(1124848809);
            Console.WriteLine(item.Fields.Count);
        }
