	using System;
	using System.Collections.Generic;
	[Serializable]
	public class SomeStack
	{
	    private readonly object stackLock = new object();
	    private readonly Stack<WorkItem> stack;
		public ContextStack()
		{
			this.stack = new Stack<WorkItem>();
		}
		public IContext Push(WorkItem context)
		{
			lock (this.stackLock)
			{
				this.stack.Push(context);
			}
			return context;
		}
		public WorkItem Pop()
		{
			lock (this.stackLock)
			{
				return this.stack.Pop();
			}
		}
	}
