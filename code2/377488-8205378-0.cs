    using System;
     
    public class Collect : IEquatable<Collect>
    {
         public string name{ get; set; }
         public int id { get; set; }
         public DateTime registerDate { get; set; }
     
         public bool Equals(Collect other)
         {
             if(other == null)
             {
                    return false;
             }
             return this.id == other.id;
         }
    }
