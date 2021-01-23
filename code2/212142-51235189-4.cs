    	public static IEnumerable<T> TopologicalSequence42<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> deps)
		{
			HashSet<T> yielded = new HashSet<T>();
			HashSet<T> visited = new HashSet<T>();
			Stack<Tuple<T, IEnumerator<T>>> stack = new Stack<Tuple<T, IEnumerator<T>>>();
			foreach (T t in source)
			{
				stack.Clear();
				Visit42(t, visited, deps, stack, yielded);
				while (stack.Count > 0)
				{
					var p = stack.Peek();
					bool depPushed = false;
					while (p.Item2.MoveNext())
					{
						if (Visit42(p.Item2.Current, visited, deps, stack, yielded))
						{
							depPushed = true;
							break;
						}
					}
					if (!depPushed)
					{
						p = stack.Pop();
						if (!yielded.Add(p.Item1))
							throw new Exception("bug");
						yield return p.Item1;
					}
				}
			}
		}
    	/// <summary>
		/// return true if dep pushed
		/// </summary>
		private static bool Visit42<T>(T curr, HashSet<T> visited, Func<T, IEnumerable<T>> deps, Stack<Tuple<T, IEnumerator<T>>> stack, HashSet<T> yielded)
		{
			if (!visited.Contains(curr))
			{
				visited.Add(curr);
				stack.Push(new Tuple<T, IEnumerator<T>>(curr, deps(curr).GetEnumerator()));
				return true; // deps pushed
			}
			else if (!yielded.Contains(curr))
				throw new Exception("cycle");
			return false;
		}
