    public class Ancestor<T, U> 
    {
         public Ancestor(T father, U mother)
         {
             this.Father = father;
             this.Mother = mother;
         }
        
         public T Father { get; private set; }
         public U Mother { get; private set; } 
    }
        
    static void Main(string[] args)
    {
         var instance = new Ancestor<Father, Mother>(new Father(), new Mother());
         instance.Father.FatherName = "The father name";
    }
