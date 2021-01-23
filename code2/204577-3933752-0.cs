    table.AsEnumerable( ).Where( item => item.Field<int>( "One" ) == 1 ).First( );
You need following using statements:
 
    using System.Data.Linq;
    using System.Linq;
