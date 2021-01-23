    using System;
    using System.Collections;
    
    public class SamplesArrayList  {
    
       public class myReverserClass : IComparer  {
    
          // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
          int IComparer.Compare( Object x, Object y )  {
              // you can implement this method as you wish! cast your x and y objects and access to their properties.
              return( (new CaseInsensitiveComparer()).Compare( y, x ) );
          }
    
       }
    
       public static void Main()  {
    
          // Creates and initializes a new ArrayList.
          ArrayList myAL = new ArrayList();
          myAL.Add( "The" );
          myAL.Add( "quick" );
          myAL.Add( "brown" );
          myAL.Add( "fox" );
          myAL.Add( "jumps" );
          myAL.Add( "over" );
          myAL.Add( "the" );
          myAL.Add( "lazy" );
          myAL.Add( "dog" );
    
          // Displays the values of the ArrayList.
          Console.WriteLine( "The ArrayList initially contains the following values:" );
          PrintIndexAndValues( myAL );
    
          // Sorts the values of the ArrayList using the default comparer.
          myAL.Sort();
          Console.WriteLine( "After sorting with the default comparer:" );
          PrintIndexAndValues( myAL );
    
          // Sorts the values of the ArrayList using the reverse case-insensitive comparer.
          IComparer myComparer = new myReverserClass();
          myAL.Sort( myComparer );
          Console.WriteLine( "After sorting with the reverse case-insensitive comparer:" );
          PrintIndexAndValues( myAL );
    
       }
    
       public static void PrintIndexAndValues( IEnumerable myList )  {
          int i = 0;
          foreach ( Object obj in myList )
             Console.WriteLine( "\t[{0}]:\t{1}", i++, obj );
          Console.WriteLine();
       }
    
    }
