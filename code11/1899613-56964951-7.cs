    public enum EFileTag
    {
        Clean,
        Modified
    }
    public class FileTag
    {
        public EFileTag EFileTag { get; private set; }
        public char EHgFileTag { get; private set; }
        public char EGitFileTag { get; private set; }
        public FileTag(EFileTag eFileTag, char eHgFileTag, char eGitFileTag)
        {
            EFileTag = eFileTag;
            EHgFileTag = eHgFileTag;
            EGitFileTag = eGitFileTag;
        }
    }
    public class SomeClass
    {
        public static readonly Dictionary<EFileTag, FileTag> tags = new Dictionary<EFileTag, FileTag>
        {
            {EFileTag.Clean, new FileTag(EFileTag.Clean, 'C', ' ') },
            {EFileTag.Modified, new FileTag(EFileTag.Modified, 'M', 'M') },
        };
        var tag = tags[EFileTag.Clean];
        //tag would be of class FileTag
        var hgft = tag.EHgFileTag;
        //hgft would be 'C'
    }
