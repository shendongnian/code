    public class NodeList : List<Node>
    {
       public TNode this[Key key] 
       {
           get { return nodes.Where(n => n.Key == key).SingleOrDefault(); }
       }
    }
  
   
