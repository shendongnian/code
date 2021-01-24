        async void SendExplosionInfo() {
        
            cws = new ClientWebSocket();
            try {
                var myConnectTask = Task.Run(()=>cws.ConnectAsync(u, CancellationToken.None));
    
                // more code running...
    await myConnectTask; // here's where it will actually stop to wait for the completion of your task. 
                Scene.NewsFromServer("done!"); // class function to go back to main tread
            }
            catch (Exception e) { ... }
        }
