        public static IEnumerable<T> TopologicalSequenceBFS<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> dependencies)
		{
			var yielded = new HashSet<T>();
			var visited = new HashSet<T>();
			var stack = new Stack<Tuple<T, bool>>(source.Select(s => new Tuple<T, bool>(s, false))); // bool signals Add to sorted
			while (stack.Count > 0)
			{
				var item = stack.Pop();
				if (!item.Item2)
				{
					if (visited.Add(item.Item1))
					{
						stack.Push(new Tuple<T, bool>(item.Item1, true)); // To be added after processing the dependencies
						foreach (var dep in dependencies(item.Item1))
							stack.Push(new Tuple<T, bool>(dep, false));
					}
					else if (!yielded.Contains(item.Item1))
						throw new Exception("cyclic");
				}
				else
				{
					if (!yielded.Add(item.Item1))
						throw new Exception("bug");
					yield return item.Item1;
				}
			}
		}
