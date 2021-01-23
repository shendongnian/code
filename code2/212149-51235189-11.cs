    	public static IEnumerable<T> TopogicalSequenceDFS<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> deps)
		{
			HashSet<T> yielded = new HashSet<T>();
			HashSet<T> visited = new HashSet<T>();
			Stack<Tuple<T, IEnumerator<T>>> stack = new Stack<Tuple<T, IEnumerator<T>>>();
			foreach (T t in source)
			{
				stack.Clear();
				if (visited.Add(t))
					stack.Push(new Tuple<T, IEnumerator<T>>(t, deps(t).GetEnumerator()));
				while (stack.Count > 0)
				{
					var p = stack.Peek();
					bool depPushed = false;
					while (p.Item2.MoveNext())
					{
						var curr = p.Item2.Current;
						if (visited.Add(curr))
						{
							stack.Push(new Tuple<T, IEnumerator<T>>(curr, deps(curr).GetEnumerator()));
							depPushed = true;
							break;
						}
						else if (!yielded.Contains(curr))
							throw new Exception("cycle");
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
