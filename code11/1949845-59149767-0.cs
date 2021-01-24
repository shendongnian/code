    using (WebServiceHost sh = new WebServiceHost(typeof(MyService), uri))
    {
        sh.AddServiceEndpoint(typeof(IService), binding, "");
        ServiceMetadataBehavior smb;
        smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
        if (smb == null)
        {
            smb = new ServiceMetadataBehavior()
            {
                HttpGetEnabled = true
            };
            sh.Description.Behaviors.Add(smb);
        }
        sh.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = System.ServiceModel.Security.UserNamePasswordValidationMode.Custom;
        sh.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new CustUserNamePasswordVal();
        Binding mexbinding = MetadataExchangeBindings.CreateMexHttpBinding();
        sh.AddServiceEndpoint(typeof(IMetadataExchange), mexbinding, "mex");
        sh.Opened += delegate
        {
            Console.WriteLine("Service is ready");
        };
        sh.Closed += delegate
        {
            Console.WriteLine("Service is clsoed");
        };
        sh.Open();
        Console.ReadLine();
        //pause
        sh.Close();
        Console.ReadLine();
    }
