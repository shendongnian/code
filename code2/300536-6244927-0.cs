    public abstract class BaseSearchType
    {
        public int Id { get; set; }
        public string text { get; set; }
        public int value { get; set; }
    }
    public class BooleanSearchTypeTable : BaseSearchType
    { }
    public class JobStatusSearchTypeTable : BaseSearchType
    { }
    public class PersonStatusSearchTypeTable : BaseSearchType
    { }
