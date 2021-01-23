	[ContentProperty("Actions")]
	public class ExecuteActionsHandlerExtension : MarkupExtension
	{
		private readonly Collection<Action> _actions = new Collection<Action>();
		public Collection<Action> Actions { get { return _actions; } }
		public bool ThrowOnException { get; set; }
		public ExecuteActionsHandlerExtension()
		{
			ThrowOnException = true;
		}
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return new RoutedEventHandler((s, e) =>
				{
					try
					{
						foreach (var action in Actions)
						{
							action.Invoke();
						}
					}
					catch (Exception)
					{
						if (ThrowOnException) throw;
					}
				});
		}
	}
