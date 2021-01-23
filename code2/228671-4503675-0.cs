    public class ClassThatRequiresSomeRepos
    {
      IRepository<OneEntity> repoOne;
      IRepository<TwoEntity> repoTwo;
      public ClassThatRequiresSomeRepos(IRepository<OneEntity> oneEntityRepository, IRepository<TwoEntity> twoEntityRepository)
      {
        _repoOne = oneEntityRepository;
        _repoTwo = twoEntityRepository;
      }
    } 
