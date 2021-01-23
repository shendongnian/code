      /// <summary>
      /// Method that returns all the duplicates (distinct) in the collection.
      /// </summary>
      /// <typeparam name="T">The type of the collection.</typeparam>
      /// <param name="source">The source collection to detect for duplicates.</param>
      /// <param name="distinct">Specify <b>true</b> to only return distinct elements.</param>
      /// <returns>A distinct list of duplicates found in the source collection.</returns>
      /// <remarks>This is an extension method to IEnumerable&lt;T&gt;</remarks>
      public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> source, bool distinct = true)
      {
         if (source == null)
         {
            throw new ArgumentNullException("source");
         }
         // select the elements that are repeated
         IEnumerable<T> result = source.GroupBy(a => a).SelectMany(a => a.Skip(1));
         // distinct?
         if (distinct == true)
         {
            // deferred execution helps us here
            result = result.Distinct();
         }
         return result;
      }
