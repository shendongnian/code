    //----------------------------------------------------------------------------------------
    // On the server/host, create a new session
    //----------------------------------------------------------------------------------------
    RDPSession session = new RDPSession();
    
    // Then create a virtual channel
    IRDPSRAPIVirtualChannel virtualChannel1 = session.VirtualChannelManager.CreateVirtualChannel("foo", CHANNEL_PRIORITY.CHANNEL_PRIORITY_HI, (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY);
    
    // Now open the session
    session.Open()
    
    // And connect to the received event
    session.OnChannelDataReceived += new _IRDPSessionEvents_OnChannelDataReceivedEventHandler(OnChannelDataReceived);
    
    private void OnChannelDataReceived(object pChannel, int lAttendeeId, string bstrData) {
        Debug.WriteLine("Server::OnChannelDataReceived" + bstrData.Trim());
    }
    
    //----------------------------------------------------------------------------------------
    // On the Client/Viewer side.
    //----------------------------------------------------------------------------------------
    // AxRDPViewer is the RDPViewer control on your form. Connect using the appropriate criteria.
    AxRDPViewer.Connect(strInvitation, strName, strPassword);
    
    // "Bind" the virtual channel by creating one using the same name as the one created on
    // the server side.
    IRDPSRAPIVirtualChannel virtualChannel1 = RDPViewer.VirtualChannelManager.CreateVirtualChannel("foo", CHANNEL_PRIORITY.CHANNEL_PRIORITY_HI, (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY);
    
    // Hook the data received event
    RDPViewer.OnChannelDataReceived += new AxRDPCOMAPILib._IRDPSessionEvents_OnChannelDataReceivedEventHandler(RDPViewer_OnChannelDataReceived);
    
    private void RDPViewer_OnChannelDataReceived(object sender, AxRDPCOMAPILib._IRDPSessionEvents_OnChannelDataReceivedEvent e) {
        Debug.WriteLine("Client::OnChannelDataReceived:" + e.bstrData.Trim());
    }
    
    //----------------------------------------------------------------------------------------
    // Sending data
    //----------------------------------------------------------------------------------------
    
    // Now, on both the server and client side, you can send data like this:
    
    virtualChannel1.SendData("yippie!", (int)RDPENCOMAPI_CONSTANTS.CONST_ATTENDEE_ID_EVERYONE, (uint)CHANNEL_FLAGS.CHANNEL_FLAGS_LEGACY);
