	public class NoDotsEmitter : IEmitter
	{
		private readonly IEmitter inner;
		
		public NoDotsEmitter(IEmitter inner)
		{
			this.inner = inner;
		}
		
		public void Emit(ParsingEvent @event)
		{
			if (@event is DocumentEnd documentEnd)
			{
				inner.Emit(new DocumentEnd(true));
			}
			else
			{
				inner.Emit(@event);
			}
		}
	}
