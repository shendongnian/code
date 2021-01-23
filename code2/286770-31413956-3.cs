    public class BaseEntity
    {
       public Int32 Id {get; set;}
    }
    public class AnyDerivedClass : BaseEntity
    {
      // Lorem Ipsum
    }
    private void DoAnything(List<AnyDerivedClass> myList)
    {
        String ids = this.ConcatIds<AnyDerivedClass>(myList);
    }
