        private readonly IHubContext<MyHub,IMyHubInterface> _hubContext;
        public MyController(MyHub,IMyHubInterface hubContext)
        {
            _hubContext = hubContext;
        }
        public bool SendViaSignalR()
        {
            _hubContext.Clients.All.MyClientSideSignalRMethod(new MyModel());
            return true;
        }
