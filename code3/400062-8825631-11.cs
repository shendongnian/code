        public class RepoFactory : IRepoFactory
        {
             public IInstrumentRepo CreateInstrumentRepo(ISession s)
             {
                 return new InstumentRepo(s);
             }
        }
