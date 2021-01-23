    namespace ConsoleApplication33 {
      public static class Program {
        private static void Main() {
          var t1=new Holder<int>(4);
          var t2=new Holder<int>(3);
          var t3=new Holder<int>(2);
          var t4=new Holder<int>(1);
          var vars=new[] {t1, t2, t3, t4};
          for(var i=0; i<4; i++) {
            ChangeVar(vars[i], i);
          }
        }
        static void ChangeVar<T>(Holder<T> thatVar, T newValue) {
          thatVar.Value=newValue;
        }
        public class Holder<T> {
          public T Value { get; set; }
          public Holder(T value=default(T)) {
            Value=value;
          }
        }
      }
    }
