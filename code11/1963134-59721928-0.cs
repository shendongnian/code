    public abstract class MasterClass {
        public abstract void SpecificMethod();
    }
    public class SubClass1 : MasterClass {
        public overrides void SpecificMethod()
        {
            //something specific to SubClass1
        }
    }
    public class SubClass2 : MasterClass {
        public overrides void SpecificMethod()
        {
            //something specific to SubClass2
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
