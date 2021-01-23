    using WebSocket4Net;
    //Create new socket connection
    WebSocket socket = new WebSocket(tab.webSocketDebuggerUrl);
    socket.MessageReceived += MessageReceived;
    socket.Open();
    socket.Send("String to send");
    private static void Ss_MessageReceived(object sender, WebSocket4Net.MessageReceivedEventArgs e)
    {
        //Handle here response from server
    }
