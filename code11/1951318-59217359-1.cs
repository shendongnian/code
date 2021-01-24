	public static class X
	{
		public static IObservable<Event<T>> GroupEvents<T>(this IObservable<Event<T>> source)
		{
			return source
				.Scan((groupId: 1, stack: ImmutableStack<ImmutableList<Event<T>>>.Empty, output: (Event<T>)null), (state, inEvent) =>
				{
					if(inEvent.Type == EventType.Data)
					{
						if (state.stack.IsEmpty)
							return (state.groupId + 1, state.stack, new Event<T>(state.groupId, EventType.Data, inEvent.Data));
						else
						{
							var newEvent = new Event<T>(state.stack.Peek()[0].Id, EventType.Data, inEvent.Data);
							var newList = state.stack.Peek().Add(newEvent);
							var newStack = state.stack.Pop().Push(newList);
							return (state.groupId, newStack, null);
						}
					}
					
					if(inEvent.Type == EventType.BeginGroup)
					{
						var newEvent = new Event<T>(state.groupId, EventType.BeginGroup, inEvent.Data);
						return (state.groupId + 1, state.stack.Push(ImmutableList<Event<T>>.Empty.Add(newEvent)), null);
					}
	
					if (inEvent.Type == EventType.EndGroup)
					{
						var newEvent = new Event<T>(state.stack.Peek()[0].Id, EventType.EndGroup, inEvent.Data);
						var newList = state.stack.Peek().Add(newEvent);
						var newStack = state.stack.Pop();
						var toEmit = new GroupEvent<T>(newList[0].Id, newList);
						if(newStack.IsEmpty)
							return (state.groupId, newStack, toEmit);
						else
						{
							var parentList = newStack.Peek().Add(toEmit);
							newStack = newStack.Pop().Push(parentList);
							return (state.groupId, newStack, null);
						}
					}
					
					throw new NotImplementedException();
				})
				.Where(t => t.output != null)
				.Select(t => t.output);
		}
	}
