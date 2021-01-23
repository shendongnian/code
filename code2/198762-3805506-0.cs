    public static class EnumerableExt
    {
        // Eric Lippert's Cartesian Product operator...
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(
              this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = 
                       new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
              emptyProduct,
              (accumulator, sequence) =>
                from accseq in accumulator
                from item in sequence
                select accseq.Concat(new[] { item }));
        }
    }
    class MDFill
    {
        public static void Main()
        {
            // create an arbitrary multidimensional array
            Array mdArray = new int[2,3,4,5];
            // create a sequences of sequences representing all of the possible
            // index positions of each dimension within the MD-array
            var dimensionBounds = 
                Enumerable.Range(0, mdArray.Rank)
                   .Select(x => Enumerable.Range(mdArray.GetLowerBound(x),
                          mdArray.GetUpperBound(x) - mdArray.GetLowerBound(x)+1));
            // use the cartesian product to visit every permutation of indexes
            // in the MD array and set each position to a specific value...
            int someValue = 100;
            foreach( var indexSet in dimensionBounds.CartesianProduct() )
            {
                mdArray.SetValue( someValue, indexSet.ToArray() );
            }
        }
    }
