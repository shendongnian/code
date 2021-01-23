    	public static IEnumerable<T> TopogicalSequence<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> deps, bool preventDepsOutsideSource = true)
		{
			HashSet<T> hsSource = null;
			if (preventDepsOutsideSource)
				hsSource = new HashSet<T>(source);
			var visited = new HashSet<T>();
			Stack<T> stack = new Stack<T>();
			HashSet<T> hsStack = new HashSet<T>();
			foreach (T t in source)
			{
				if (visited.Contains(t))
					continue;
				stack.Clear();
				hsStack.Clear();
				stack.Push(t);
				hsStack.Add(t);
				while (stack.Count > 0)
				{
					var ele = stack.Peek();
					bool depPushed = false;
					foreach (var dep in deps(ele).Where(d => !visited.Contains(d)))
					{
						if (preventDepsOutsideSource && !hsSource.Contains(dep))
							throw new Exception("dep outside source");
						if (!hsStack.Add(dep))
							throw new Exception("cyclic");
						stack.Push(dep);
						depPushed = true;
					}
					if (!depPushed)
					{
						ele = stack.Pop();
						if (!visited.Add(ele))
							throw new Exception("impossible");
						yield return ele;
					}
				}
			}
		}
