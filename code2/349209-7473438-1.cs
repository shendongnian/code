    abstract class Mechanism {
         public abstract IEnumerable<string> GetDetails();
    }
    class Automobile : Mechanism {
         public override IEnumeable<string> GetDetails() {
             return a sequence of strings;
         }
    }
    class Motorcycle : Mechanism {
         public override IEnumeable<string> GetDetails() {
             return a sequence of strings;
         }
    }
