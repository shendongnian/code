        //partition an IEnumerable into fixed size IEnumerables
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int partitionSize)
		{
			return source
				.Select((value, index) => new { Index = index, Value = value })
				.GroupBy(i => i.Index / partitionSize)
				.Select(i => i.Select(i2 => i2.Value));
		}
        public IEnumerable<T> Get(List<long> listOfIDs)
        {
            var partitionedList = listOfIDs.Partition(1000).ToList();
        	List<ICriterion> criterions = new List<ICriterion>();
        	foreach (var ids in partitionedList)
        	{
        		criterions.Add(Restrictions.In("Id", ids.ToArray()));
        	}
        	var criterion = criterions.Aggregate(Restrictions.Or);
        	var criteria = session.CreateCriteria<T>().Add(criterion);
        	return criteria.Future<T>();
        }
