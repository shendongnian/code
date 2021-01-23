      public T CreateInstance()
        {
            string fullClassName = typeof(T).ToString();
            string[] splitClassName = fullClassName.Split('.');
            _className = splitClassName[2];
            _assemblyName = splitClassName[0] + "." + _client + "." + splitClassName[1];
            _fullyQualifiedClassName = _assemblyName + "." + _className;
            // use caching
            T obj;
            if (HttpContext.Current.Cache[_fullyQualifiedClassName] == null)
            {
                obj = (T)Activator.CreateInstance(Type.GetType(_fullyQualifiedClassName + "," + _assemblyName));
                HttpContext.Current.Cache.Insert(_fullyQualifiedClassName, obj, null, DateTime.Now.AddMinutes(1), TimeSpan.Zero);
            }
            else
            {
                obj = (T)HttpContext.Current.Cache[_fullyQualifiedClassName];
            }
            return obj;
        }
    protected void Page_Load(object sender, EventArgs e)
    {
        InvoiceFactory inv;
        Stopwatch globalTimer = Stopwatch.StartNew();
        //normal instantiation
        globalTimer = Stopwatch.StartNew();
        for (int x = 0; x <= 10000; x++)
            inv = new InventorySuit.Client1.BusinessLogic.Invoice;
        globalTimer.Stop();
        Response.Write(globalTimer.ElapsedMilliseconds + "<BR>");
        //result 0ms
        
        // using singleton factory w/o caching
        globalTimer = Stopwatch.StartNew();
        for (int x = 0; x <= 10000; x++)
            inv = new FactoryInstantiator<InvoiceFactory>().CreateInstance();
        globalTimer.Stop();
        Response.Write(globalTimer.ElapsedMilliseconds + "<BR>");
        //result 129ms
        // using singleton factory w/ caching
        for (int x = 0; x <= 10000; x++)
            inv = FactoryInstantiator<InvoiceFactory>.Instance.CreateInstance();
        globalTimer.Stop();
        Response.Write(globalTimer.ElapsedMilliseconds + "<BR>");
        //result 21ms
        
    }
