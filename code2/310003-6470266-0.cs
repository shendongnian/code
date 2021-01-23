    public partial class SomeClass : IEquatable<SomeClass>
    {
         public override bool Equals(Object obj)
         {
             return Equals(obj as SomeClass);
         }
         public bool Equals(SomeClass obj)
         {
             if (obj == null) 
                 return false;
             return Id == obj.Id;
         }
         public override int GetHashCode()
         {
             return Id.GetHashCode();
         }
    } 
