    public interface ILiteralInteger
    {
       int Literal { get; }
    }
    public class LiteralInt10 : ILiteralInteger
    {
       public int Literal { get { return 10; } }
    }
    public class MyTemplateClass< L > where L: ILiteralInteger, new( )
    {
       private static ILiteralInteger MaxRows = new L( );
       public void SomeFunc( )
       {
          // use the literal value as required
          if( MaxRows.Literal ) ...
       }
    }
