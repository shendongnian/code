    	public static IEnumerable<T> TopogicalSequence<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> deps)
		{
			var visited = new HashSet<T>();
			Stack<T> stack = new Stack<T>();
			foreach (T t in source)
			{
				if (visited.Contains(t))
					continue;
				stack.Clear();
				stack.Push(t);
				while (stack.Count > 0)
				{
					var ele = stack.Peek();
					bool depPushed = false;
					foreach (var dep in deps(ele).Where(d => !visited.Contains(d)))
					{
						stack.Push(dep);
						depPushed = true;
					}
					if (!depPushed)
					{
						ele = stack.Pop();
						if (visited.Add(ele))
							yield return ele;
					}
				}
			}
		}
