    public abstract class Node
    {
        public virtual NodeModel CreateModel()
        {
            throw new NotImplementedException();
        }
    }
    
    public class Folder : Node
    {
        public virtual FolderModel CreateModel()
        {
            // Implementation
        }
    }
