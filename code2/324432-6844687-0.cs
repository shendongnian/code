    abstract class basetype
    {
      //..
      public abstract void Accept(Visitor v);
      //..
    }
    
    class TypeA
    {
      //..
      //..
      public override void Accept(Visitor v) { v.Visit(this); }
    }
    
    abstract class Visitor
    {
      public abstract void Visit(TypeA a);
      public abstract void Visit(TypeB b);
    }
