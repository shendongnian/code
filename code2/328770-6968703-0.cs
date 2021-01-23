    public class ServiceA
    {
     public PersonWorkerDTO GetPersonWorker()
     {
          RepositoryA.GetSomething();
          RepositoryB.GetSomething();
          RepositoryC.GetSomething();
     }
    }
