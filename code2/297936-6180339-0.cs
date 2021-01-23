        public static IQueryable<TResultElement> RunQueryWithBatching<TBatchElement, TResultElement>(this IList<TBatchElement> listToBatch, int batchSize, Func<List<TBatchElement>, IQueryable<TResultElement>> initialQuery)
        {
            return RunQueryWithBatching(listToBatch, initialQuery, batchSize);
        }
        public static IQueryable<TResultElement> RunQueryWithBatching<TBatchElement, TResultElement>(this IList<TBatchElement> listToBatch, Func<List<TBatchElement>, IQueryable<TResultElement>> initialQuery)
        {
            return RunQueryWithBatching(listToBatch, initialQuery, 0);
        }
        public static IQueryable<TResultElement> RunQueryWithBatching<TBatchElement, TResultElement>(this IList<TBatchElement> listToBatch, Func<List<TBatchElement>, IQueryable<TResultElement>> initialQuery, int batchSize)
        {
            if (listToBatch == null)
                throw new ArgumentNullException("listToBatch");
            if (initialQuery == null)
                throw new ArgumentNullException("initialQuery");
            if (batchSize <= 0)
                batchSize = 1000;
            int batchCount = (listToBatch.Count / batchSize) + 1;
            var batchGroup = listToBatch.AsQueryable().Select((elem, index) => new { GroupKey = index % batchCount, BatchElement = elem }); // Enumerable.Range(0, listToBatch.Count).Zip(listToBatch, (first, second) => new { GroupKey = first, BatchElement = second });
            var keysBatchGroup = from obj in batchGroup
                                         group obj by obj.GroupKey into grouped
                                         select grouped;
            var groupedBatches = keysBatchGroup.Select(key => key.Select((group) => group.BatchElement));
            var map = from employeekeysBatchGroup in groupedBatches
                      let batchResult = initialQuery(employeekeysBatchGroup.ToList()).ToList() // force to memory because of stupid translation error in linq2sql
                      from br in batchResult
                      select br;
            return map;
        }
