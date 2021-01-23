    public interface ITagable
    {
        IEnumerable<Tag> Tags { get; }
        void Tag(Tag tag);
        void Untag(Tag tag);
    }
