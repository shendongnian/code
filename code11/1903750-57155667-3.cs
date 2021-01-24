    public static IEnumerable<Client> GetClients(MySettings settings) {
        return new List<Client>() {
            new Client {
                ClientName = settings.ClientName,
                //...omitted for brevity
