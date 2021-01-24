        static async Task<int> Main()
        {
            var podio = new Podio(clientId, clientSecret);
            await podio.AuthenticateWithPassword(username, password);
            var item = await podio.ItemService.GetItem(1124848809);
            Console.WriteLine(item.Fields.Count);
            return 0;
        }
