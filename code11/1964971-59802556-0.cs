    public interface ITaggedItem {
        string Tag {get;set;}
    }
    public class TaggedItem: ITaggedItem {
        public string Tag {get;set;}
    }
    public class Category: TaggedItem{
    }
    var b = (IOrderedEnumerable<IGrouping<ITaggedEntity, ITaggedEntity>>)i;
