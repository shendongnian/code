    public struct BillingData
    {
        public int CustomerTrackID, CustomerID;
        public DateTime BillingDate;
    }
    public Queue<BillingData> customerQueue = new Queue<BillingData>();
    volatile static int ThreadProcessCount = 0;
    readonly static object threadprocesslock = new object();
    readonly static object queuelock = new object();
    readonly static object countlock = new object();
    AsyncCallback asyncCallback
    // Pulling the Data Aync from the Database
    private void StartProcess()
    {
      SqlCommand command = SQLHelper.GetCommand("GetRecordsByBillingTrackID");
      command.Connection = SQLHelper.GetConnection("Con");SQLHelper.DeriveParameters(command);
      command.Parameters["@TrackID"].Value = trackid;
      asyncCallback = new AsyncCallback(FetchData);
      command.BeginExecuteXmlReader(asyncCallback, command);
    }
    public void FetchData(IAsyncResult c1)
        {
            SqlCommand comm1 = (SqlCommand)c1.AsyncState;
            System.Xml.XmlReader xr = comm1.EndExecuteXmlReader(c1);
            xr.Read();
            string data = "";
            while (!xr.EOF)
            {
            data = xr.ReadOuterXml();
            XmlDocument dom = new XmlDocument();
            dom.LoadXml("<data>" + data + "</data>");
            BillingData billingData;
            billingData.CustomerTrackID = Convert.ToInt32(dom.FirstChild.ChildNodes[0].Attributes["CustomerTrackID"].Value);
            billingData.CustomerID = Convert.ToInt32(dom.FirstChild.ChildNodes[0].Attributes["CustomerID"].Value);
            billingData.BillingDate = Convert.ToDateTime(dom.FirstChild.ChildNodes[0].Attributes["BillingDate"].Value);
    lock (queuelock)
    {
       if (!customerQueue.Contains(billingData))
       {
         customerQueue.Enqueue(billingData);
       }
    }
       AssignThreadProcessToTheCustomer();
  
    }
  
    xr.Close();
 
    }
 
    // Assign the Threads based on the data pulled
    private void AssignThreadProcessToTheCustomer()
    {
    int TotalProcessThreads =  5;
    int TotalCustomersPerThread = 5;
    if (ThreadProcessCount < TotalProcessThreads)
    {
    int ThreadsNeeded = (customerQueue.Count % TotalCustomersPerThread == 0) ?    (customerQueue.Count / TotalCustomersPerThread) : (customerQueue.Count / TotalCustomersPerThread + 1);
    int count = 0;
     if (ThreadsNeeded > ThreadProcessCount)
    {
     count = ThreadsNeeded - ThreadProcessCount;
     if ((count + ThreadProcessCount) > TotalProcessThreads)
        count = TotalProcessThreads - ThreadProcessCount;
    }
    for (int i = 0; i < count; i++)
    {
    ThreadProcess objThreadProcess = new ThreadProcess(this);
    ThreadPool.QueueUserWorkItem(objThreadProcess.BillingEngineThreadPoolCallBack, count);
    lock (threadprocesslock)
    {
     ThreadProcessCount++;
    }
    }
    public void BillingEngineThreadPoolCallBack(object threadContext)
    {
    BillingData? billingData = null;
    while (true)
    {
       lock (queuelock)
       {
          billingData = ProcessCustomerQueue();
       }
     if (billingData != null)
    {
     StartBilling(billingData.Value);
    }
    else
     break;
    More....
    }
 
 
