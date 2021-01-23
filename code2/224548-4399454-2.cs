    public interface ISanitizer
    {
        string Sanitize<T>(T data_);
    }
    public virtual string Sanitize<T>(T filename_)
