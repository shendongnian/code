    class ClientHandler() {
        private readonly SemaphoreSlim _sendLock;
        public ClientHandler(HttpContext context) {
            _sendLock = new SemaphoreSlim(1, 1);
            //....
        }
    
        public async Task SendAsync(string msg) {
            await _sendLock.WaitAsync();
            try {
                await webSocket.SendAsync( 
                    System.Text.Encoding.UTF8.GetBytes(msg.ToString()),
                    System.Net.WebSockets.WebSocketMessageType.Text,
                    true,
                    System.Threading.CancellationToken.None);
            } finally {
                _sendLock.Release();
            }
        }
    }
