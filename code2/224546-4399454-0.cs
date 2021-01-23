    public interface ISanitizer<T>
    {
        T Sanitize(T data_);
    }
    
    public class BasicFilenameSanitizer : ISanitizer<string>
