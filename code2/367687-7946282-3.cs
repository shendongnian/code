    public interface IAncestor
    {
        string Name { get; set; }
    }
    
    public sealed class Father : IAncestor
    {
    }
    public sealed class Mother : IAncestor
    {
    }
    public sealed class ParentsAncestor<T, U> 
     where T: IAncestor
     where U: IAncestor
    {
         public ParentsAncestor(T father, U mother)
         {
             this.Father = father;
             this.Mother = mother;
         }
        
         public T Father { get; private set; }
         public U Mother { get; private set; } 
    }
        
    static void Main(string[] args)
    {
         var instance = new ParentsAncestor<Father, Mother>(new Father(), new Mother());
         instance.Father.Name = "The father name";
    }
