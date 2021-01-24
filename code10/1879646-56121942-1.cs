        private readonly IApiFlTester _apiFileTester;
       
        public ApiFileSendingController(DTO dto, IApiFlTester tester) : base(dto)
        {
           if (tester is null)
            _tester = GetApiTesterViaReflection(); 
           else
            _tester = tester;
        }
        public ApiFileSendingController(DTO dto) : base(dto)
        {
            _apiFileTester = GetApiTesterViaReflection();
        }
        public void Send(List<AftInvFileDTO> filesToSendRetry = null)
        {
            _apiFileTester.RegisterTestingMethods();
        }
        private IApiFlTester GetApiTesterViaReflection()
        {
            Type type = typeof(IApiFlTester).Assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IApiFlTester))).FirstOrDefault();
            return Activator.CreateInstance(type) as IApiFlTester;
        }
    }
