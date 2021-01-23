    public class EnumerableDoubleComparer : IComparer<IEnumerable<double>>
    {
        public int Compare( IEnumerable<double> a, IEnumerable<double> b )
        {
            var counts = a.Select( (k,i) => new { Value = k, Index = i } )
                          .Join( b.Select( (k,i) => new { Value = k, Index = i } ),
                                 outer => outer.Index,
                                 inner => inner.Index,
                                 (outer,inner) => outer.Value > inner.Value
                                                      ? "A"
                                                      : (inner.Value > outer.Value
                                                            ? "B"
                                                            : "" ) )
                          .GroupBy( listID => listID )
                          .Select( g => new { g.Key, Count = g.Count() } );
            
            // you could also use SingleOrDefault on the collection and check for null
            var aCount = counts.Where( c => c.Key == "A" )
                               .Select( c => c.Count )
                               .SingleOrDefault();
            var bCount = counts.Where( c => c.Key == "B" )
                               .Select( c => c.Count )
                               .SingleOrDefault();
    		
            return aCount - bCount;
        }
    }
