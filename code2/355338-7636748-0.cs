    static class Utility
    {
        // Helper method since Add is void
        static List<T> Plus<T>(this List<T> list, T newElement)
        {
            list.Add(newElement);
            return list;
        }
        // Helper method since Add is void
        static List<List<T>> PlusToLast<T>(this List<List<T>> lists, T newElement)
        {
            lists.Last().Add(newElement);
            return lists;
        }
        static IEnumerable<IEnumerable<T>> SplitIntoSections<T>
             (IEnumerable<T> content, 
              Func<T, bool> isSectionDivider)
        {
            return content.Aggregate(                      // a LINQ method!
                new List<List<T>>(),                       // start with empty sections
                (sectionsSoFar, element) =>
                isSectionDivider(element)
                    ? sectionsSoFar.Plus(new List<T>())
                      // create new section when divider encountered
               
                    : sectionsSoFar.PlusToLast(element)
                      // add normal element to current section
                );
        }
    }
