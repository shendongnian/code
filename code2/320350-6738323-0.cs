    public abstract class AbstractSupertype
    {
      public void Alpha()
      {
        Console.WriteLine( "AbstractSupertype.Alpha()" ) ;
        return ;
      }
      public abstract void Bravo() ;
      public virtual  void Charlie()
      {
        Console.WriteLine( "AbstractSupertype.Charlie()" ) ;
        return ;
      }
    }
  
    public class ConcreteSubtype : AbstractSupertype
    {
      public new void Alpha()
      {
        Console.WriteLine( "ConcreteSubtype.Alpha()" ) ;
      }
      public override void Bravo()
      {
        Console.WriteLine( "ConcreteSubtype.Bravo()" ) ;
      }
      public override void Charlie()
      {
        Console.WriteLine( "ConcreteSubtype.Charlie()" ) ;
      }
    }
    class Program
    {
      static void Main( string[] args )
      {
        ConcreteSubtype   subTypeInstanceReference   = new ConcreteSubtype() ;
        AbstractSupertype superTypeInstanceReference = subTypeInstanceReference ;
      
        subTypeInstanceReference.Alpha()     ; // invokes subtype's method
        superTypeInstanceReference.Alpha()   ; // invokes supertype's method
      
        subTypeInstanceReference.Bravo()     ; // invokes subtype's method
        superTypeInstanceReference.Bravo()   ; // invokes subtype's method
      
        subTypeInstanceReference.Charlie()   ; // invokes subtype's method
        superTypeInstanceReference.Charlie() ; // invokes subtype's method
      
        return ;
      }
    }
