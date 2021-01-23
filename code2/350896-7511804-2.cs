    public abstract class Node<T> where T : NodeModel
    {
        public abstract T CreateModel();
    }
    
    public class Folder : Node<FolderModel>
    {
        public override FolderModel CreateModel()
        {
            // Implementation
        }
    }
    
    public class Item : Node<ItemModel>
    {
        public override ItemModel CreateModel()
        {
            // Implementation
        }
    }
