    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication33 {
      public class Program {
        public static void Main() {
          var foo1=new Foo<ConcreteClass1>();
          var foo2=new Foo<ConcreteClass2>();
          var bar=new Bar(100);
    
          var result1=foo1.M(bar);
          var result2=foo2.M(bar);
          Debug.Print("result1.SomeProperty="+result1.SomeProperty);
          Debug.Print("result2.SomeProperty="+result2.SomeProperty);
        }
      }
    
      //----------------------------------------------------------------------------
      // these definitions can appear in project 1
      // notice that project 1 does not have any dependencies on Bar
      //----------------------------------------------------------------------------
    
      /// <summary>
      /// This interface needs a line for each class in the hierarchy
      /// </summary>
      public interface IABCVisitor<out T> {
        T Visit(AbstractBaseClass x);
        T Visit(ConcreteClass1 x);
        T Visit(ConcreteClass2 x);
      }
    
      public abstract class AbstractBaseClass {
        public int SomeProperty { get; set; }
    
        /// <summary>
        /// All of AbstractBaseClasses' children need to override this property
        /// </summary>
        public virtual T AcceptVisitor<T>(IABCVisitor<T> visitor) {
          return visitor.Visit(this);
        }
      }
    
      public class ConcreteClass1 : AbstractBaseClass {
        public override T AcceptVisitor<T>(IABCVisitor<T> visitor) {
          return visitor.Visit(this);
        }
      }
    
      public class ConcreteClass2 : AbstractBaseClass {
        public override T AcceptVisitor<T>(IABCVisitor<T> visitor) {
          return visitor.Visit(this);
        }
      }
    
      //----------------------------------------------------------------------------
      // these definitions can appear in project 2
      //----------------------------------------------------------------------------
    
      public class Bar {
        public int MagicValue { get; private set; }
    
        public Bar(int magicValue) {
          MagicValue=magicValue;
        }
      }
    
      public class Foo<T> where T : AbstractBaseClass, new() {
        public T M(Bar bar) {
          T t=new T();
          t.SomeProperty=t.AcceptVisitor(new CalculateTheRightValue(bar));
          return t;
        }
      }
    
      public class CalculateTheRightValue : IABCVisitor<int> {
        private readonly Bar bar;
    
        public CalculateTheRightValue(Bar bar) {
          this.bar=bar;
        }
    
        public int Visit(AbstractBaseClass x) {
          throw new NotImplementedException("not implemented for type "+x.GetType().Name);
        }
    
        public int Visit(ConcreteClass1 x) {
          return bar.MagicValue+73;
        }
    
        public int Visit(ConcreteClass2 x) {
          return bar.MagicValue-12;
        }
