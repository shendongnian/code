    public abstract class TreeItemBase
    {
        public List<TreeItemBase> ChildItems { get; set; }
    }  
    public class ParentClusterViewModel : TreeItemBase { ... }
    public class ChildClusterViewModel : TreeItemBase { ... }
    public class QuestionViewModel : TreeItemBase { ... }
