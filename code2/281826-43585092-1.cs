    public class TopClass
    {
      DerivedClass MyDerivedClass;
      public int GetDerivedClassPublicField
      {
        get
          {
            DerivedClass MyDerivedClass = new DerivedClass();
            return DerivedClass.myfield;//here is access to your abstract class field from outside
          }
       }
      // Private classes must be nested
      private abstract class AbstractClass
      {
        public int myfield = 1;
      }
      private class DerivedClass : AbstractClass
      {
        ... (derived classes inherit the non-abstract field from the abstract parent by default here) ...
      }
    }
    // now call the public top level class property to get the field in the abstract class
    TopClass MyTopClass = new TopClass();
    int myInt = MyTopClass.GetDerivedClassPublicField;
