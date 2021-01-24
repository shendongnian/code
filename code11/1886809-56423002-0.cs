     private static void SendCallback(IAsyncResult ar) {
    try {
        Socket handler = (Socket)ar.AsyncState;
        int bytesSent = handler.EndSend(ar);
        handler.Shutdown(SocketShutdown.Both);
        handler.Close();
    } catch (Exception e) {
        MonoBehaviour.print(e.ToString());
    }
     }
