    public abstract class ViewModelBase
    {
        public IEnumerable<Tag> Tags { get; private set; }
        public ViewModelBase()
        {
            Tags = GetTagsFromDatabase();
        }
    }
