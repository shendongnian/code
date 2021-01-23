    public abstract class Node 
    { 
        public virtual NodeModel CreateModel() 
        { 
            throw new NotImplementedException(); 
        } 
    } 
     
    public class FolderModel : NodeModel
    {
      // blah
    }
    public class Folder : Node 
    { 
        public virtual NodeModel CreateModel() 
        { 
          var node = new FolderModel();
          blah;
          return node; // FolderModel derives from NodeModel
        } 
    } 
     
    public class ItemModel : NodeModel
    {
      // blah
    }
    public class Item : Node 
    { 
        public virtual NodeModel CreateModel() 
        { 
          var node = new ItemModel();
          blah;
          return node; // ItemModel derives from NodeModel
        } 
    } 
    public foo(Node node)
    {
      var model = node.CreateModel();
    }
