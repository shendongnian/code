    public static HubConnection Create(string serverUri, string hubName, Func<Task<string>> getToken)
        {
            var server = $"https://{serverUri}/{hubName}"; 
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(server, options => {
                    options.AccessTokenProvider = getToken;
                })
                .Build();
            return hubConnection; 
        }
