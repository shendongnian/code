    /// <summary>
    /// Establishes a socket server for communication with each chapter build script so we can get progress updates.
    /// </summary>
    private void EstablishSocketServer() {
    	//_dialog.SetMessage("Establishing socket connection for updates. \n");
    	TearDownSocketServer();
    	
    	Thread currentThread;
    	
    	_ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
    	_listener = new TcpListener(_ipAddress, SOCKET_PORT);
    	_listener.Start();
    	
    	UnityEngine.Debug.Log("Server mounted, listening to port " + SOCKET_PORT);
    	
    	_builderCommThreads = new List<Thread>();
    	
    	for (int i = 0; i < 1; i++) {
    		currentThread = new Thread(new ThreadStart(HandleIncomingSocketMessage));
    		_builderCommThreads.Add(currentThread);
    		currentThread.Start();
    	}
    }
    
    /// <summary>
    /// Tears down socket server.
    /// </summary>
    private void TearDownSocketServer() {
    	_builderCommThreads = null;
    	
    	_ipAddress = null;
    	_listener = null;
    }
