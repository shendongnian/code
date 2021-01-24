    public static class SocketService {
        public static Socket socket { get; set; }
        public static void Init() {
            socket = IO.Socket("http://localhost:3000");
        }
    }
