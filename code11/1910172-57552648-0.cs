    public class SocketDick {
            private readonly Dictionary<string, Socket> sockets = new Dictionary<string, Socket>();
            
            private readonly object @lock = new object();
            public bool TryAdd(string key,Socket socket) {
                bool added;
                lock (@lock) {
                    added=this.sockets.TryAdd(key, socket);
                }
                return added;
            }
            public bool TryRemove(string key) {
                bool remove = false ;
                if(this.sockets.Any(x=>x.Key==key)) {
                    lock (@lock) {
                        remove = this.sockets.Remove(key);
                    }
                }
                return remove;
            }
        }
