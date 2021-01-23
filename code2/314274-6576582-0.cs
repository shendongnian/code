     public class Sample
     {
         object synch = new object();
         List<Something> list = new List<Something>();
         void Add(Something something)
         {
            lock (synch) { list.Add(something); }
         }
         // Add the methods for update and delete.
      }
