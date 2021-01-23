    public class BaseClass
    {
          public virtual BaseClass SplitObject()
          {
               BaseClass splitObject = new BaseClass();
               //initialize the split object
               return splitObject;
          }
    }
    
    public class DerivedClass : BaseClass
    {
         public override BaseClass SplitObject()
         {
              DerivedClass derivedSplitObject = new DerivedClass();
              //initialize the derived split object
              return derivedSplitObject;
         }
    }
         
 
}
