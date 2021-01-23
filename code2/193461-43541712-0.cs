    private static bool IsSameCollections(ICollection<> collection1, ICollection<> collection2)
            {
              return collection1.Count == collection2.Count &&
         (collection1.Intersect(collection2).Count() == collection1.Count);
            }
