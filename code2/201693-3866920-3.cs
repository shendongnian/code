    abstract class Base {
      public abstract void Accept(IBaseVisitor visitor);
    }
    class A : Base {
      public override void Accept(IBaseVisitor visitor) {
        visitor.Visit(this);
      }
    }
    class B : Base {
      public override void Accept(IBaseVisitor visitor) {
        visitor.Visit(this);
      }
    }
    interface IBaseVisitor {
      void Visit(A a);
      void Visit(B b);
    }
    class MapToContractVisitor : IBaseVisitor {
      public ContractBase Contract { get; private set; }
      public void Visit(A a) {
        Contract = Mapper.Map<A, ContractA>(a); 
      }
      public void Visit(B b) {
        Contract = Mapper.Map<B, ContractB>(b);
      }
    }
