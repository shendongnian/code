    using System;
    using System.Collections.Generic;
    
    namespace Sandbox
    {
      class Program
      {
        
        enum ListPosition : byte
        {
          First     = 0x01       ,
          Only      = First|Last ,
          Middle    = 0x02       ,
          Last      = 0x04       ,
          Exhausted = 0x00       ,
        }
        
        private static void WalkList( List<int> numbers )
        {
          List<int>.Enumerator numberWalker = numbers.GetEnumerator();
          bool                 currFetched  = numberWalker.MoveNext();
          int                  currValue    = currFetched ? numberWalker.Current : default( int );
          bool                 nextFetched  = numberWalker.MoveNext();
          int                  nextValue    = nextFetched ? numberWalker.Current : default( int );
          ListPosition         position     ;
          
          if      (   currFetched &&   nextFetched ) position = ListPosition.First     ;
          else if (   currFetched && ! nextFetched ) position = ListPosition.Only      ;
          else if ( ! currFetched                  ) position = ListPosition.Exhausted ;
          else throw new InvalidOperationException( "Reached Unreachable Code. Hmmm...that doesn't seem quite right" );
          
          while ( position != ListPosition.Exhausted )
          {
            string article = ( position==ListPosition.Middle?"a":"the" );
            
            Console.WriteLine( "  {0} is {1} {2} item in the list" , currValue , article , position );
            
            currFetched = nextFetched ;
            currValue   = nextValue   ;
            
            nextFetched = numberWalker.MoveNext()                         ;
            nextValue   = nextFetched?numberWalker.Current:default( int ) ;
            
            if      (   currFetched &&   nextFetched ) position = ListPosition.Middle    ;
            else if (   currFetched && ! nextFetched ) position = ListPosition.Last      ;
            else if ( ! currFetched                  ) position = ListPosition.Exhausted ;
            else throw new InvalidOperationException( "Reached Unreachable Code. Hmmm...that doesn't seem quite right" );
            
          }
          
          Console.WriteLine() ;
          return ;
        }
        
        static void Main( string[] args )
        {
          List<int> list1 = new List<int>( new []{ 1 ,             } ) ;
          List<int> list2 = new List<int>( new []{ 1 , 2 ,         } ) ;
          List<int> list3 = new List<int>( new []{ 1 , 2 , 3 ,     } ) ;
          List<int> list4 = new List<int>( new []{ 1 , 2 , 3 , 4 , } ) ;
          
          Console.WriteLine( "List 1:" ) ; WalkList( list1 ) ;
          Console.WriteLine( "List 2:" ) ; WalkList( list2 ) ;
          Console.WriteLine( "List 3:" ) ; WalkList( list3 ) ;
          Console.WriteLine( "List 4:" ) ; WalkList( list4 ) ;
          
          return ;
        }
      
      }
    }
