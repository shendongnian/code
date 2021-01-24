    public abstract class MasterClass {
        public abstract void SpecificMethod();
    }
    public class SubClass1 : MasterClass {
        public override void SpecificMethod()
        {
            //something specific to SubClass1
            // use the this keyword to access the instance
        }
    }
    public class SubClass2 : MasterClass {
        public override void SpecificMethod()
        {
            //something specific to SubClass2
            // use the this keyword to access the instance
        }
    }
    public class SeparateClass
    {
        public void HandleMasterClass(MasterClass item)
        {
          /*
          stuff generic to both subclasses...
          */
          item.SpecificMethod()
        }
    }
