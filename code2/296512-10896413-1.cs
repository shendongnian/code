    using C;
    using B;
    namespace A {
      public abstract class C1 : B.C0 {
        ...
        // Getter implementation
        public override C.PropType Prop { get {return C.PropType.V1;}}
      }
    }
    using C;
    using B;
    namespace A {
      // Class implementation
      public class C2 : C1 {
        ...
      }
    }
