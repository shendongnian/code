    private bool Cancel = false;
    private void YourFunction()
    {
        do 
        {
            string foo = "Foo";
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<YourHub>();
            context.Clients.All.SendYourMessage(foo);
            Thread.Sleep(10000);
        } 
        while(!Cancel)
    }
