        abstract class A {
          public virtual string Print() {}
          public static string DoPrint(A a) {
              a.Print();
          }
        }
        class A1: A {
          public override string Print() {}
        }
        class A2: A {
          public override string Print() {}
        }
        class A3: A {
          public override string Print() {}
        }
        class Somewhere
        {
          A3 a3 = new A3();
          A.DoPrint(a3);
        }
