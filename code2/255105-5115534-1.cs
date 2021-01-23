    internal class MyLazyEntity : MyEntity
    {
        public MyLazyEntity(MyLazyEntityRepository repository)
        {
            this.Repository = repository;
        }
 
        public override IEnumerable<string> Tags
        {
            get
            {
                return this.Repository.LoadTagsForEntityFromXml(this.Id);
            }
        }
    }
    class MyLazyEntityRepository : IMyEntityRepository { }
