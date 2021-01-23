    public abstract class FileMetabaseObject {
        public abstract string Value { get; }
    }
    public class FileTag : FileMetabaseObject {
        public string Tag { get; set; }
        public override string Value { get { return Tag; } }
    }
