    public interface ITagService
    {
        void ProcessTags<TEntity>(TEntity entity, Func<IEnumerable<Tag>> featureTags, 
			string tagString) where TEntity : ITagable;
    }
