       public class FirstClass
       {
          int SomeValue;
    
          public FirstClass()
          { }
    
          public FirstClass( int SomeDefaultValue )
          {
             SomeValue = SomeDefaultValue;
          }
       }
    
    
       public class SecondClass : FirstClass
       {
          int AnotherValue;
          string Test;
    
          public SecondClass() : base( 123 )
          {  Test = "testing"; }
    
          public SecondClass( int ParmValue1, int ParmValue2 ) : this()
          {
             AnotherValue = ParmValue2;
          }
       }
