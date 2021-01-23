    abstract class Base {
      public abstract ContractBase ToContract();
    }
    class A : Base {
      public override ContractBase ToContract() {
        return Mapper.Map<A, ContractA>(this);
      }
    }
    class B : Base {
      public override ContractBase ToContract() {
        return Mapper.Map<B, ContractB>(this);
      }
    }
