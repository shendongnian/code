    long ini = Environment.TickCount;
    for (int i = 0; i < 100; i++)
    {
        Session["ClientCode"] = "Client2";
        clientInvoice = FactoryInstantiator<InvoiceFactory>.Instance.CreateInstance();
        clientInvoice.Set();
    }
    long timeCreate100Instances = Environment.TickCount - ini;
