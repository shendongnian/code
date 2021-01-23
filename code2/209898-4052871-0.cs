    namespace BaseNameSpace
    {
      public static class BaseClassExtensions
      {
        public static void Mult(this BaseClass instance)
        {
          instance.Num *= 2;
        }
      }
    }
    
    namespace DerivedNameSpace
    {
      public class DerivedClass : BaseClass
      {
        public DerivedClass(int s)
          : base(s, 0)
        {
    
        }
    
        public override void Wrt()
        {
    
          Mult(); // mult line
          base.Wrt();
        }
      }
    }
