    IAsyncResult asyncResult[20];
    ISessionFactory sessionFactories[20];
    Func<string, ISessionFactory> method = GetSessionFactory;
    for (int i = 0; i < 20; i++)
    {
        asyncResult[i] = method.BeginInvoke("RBDB", null, null);
    }
    for(int i = 0; i < 20; i++)
    {
        sessionFactories[i] = method.EndInvoke(asyncResult[i]); 
    }
