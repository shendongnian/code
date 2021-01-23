    // Three threads:
    for (int i = 0; i < 3; i++)
    {
       Thread curThread = new Thread(StartThread);
       curThread.Start();
    }
    private void StartThread()
    {
          NHibernateInitializer.Instance().InitializeNHibernateOnce(InitializeNHibernateSession);
          SomeAwesomeLongRunningPieceOfWork();            
    }
    private void InitializeNHibernateSession()
    {
       var path = ConfigurationManager.AppSettings["NHibernateConfig"];
       NHibernateSession.Init(
          new ThreadSessionStorage(),
          new string[] { "foo.Data.dll" },
          new AutoPersistenceModelGenerator().Generate(),
          "./App_Configuration/" + path);
    }
