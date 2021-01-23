	using System;
	using System.Collections.Generic;
	[Serializable]
	public class SomeStack
	{
	    private readonly object stackLock = new object();
	    private readonly Stack<WorkItem> stack;
		public ContextStack()
		{
			this.stack = new Stack<IContext>();
		}
		public IContext Push(IContext context)
		{
			lock (this.stackLock)
			{
				this.stack.Push(context);
			}
			return context;
		}
		public IContext Pop()
		{
			lock (this.stackLock)
			{
				return this.stack.Pop();
			}
		}
	}
