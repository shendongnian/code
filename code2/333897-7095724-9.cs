	[ContentProperty("Filters")]
	class FilterExtension : MarkupExtension
	{
		public enum AcceptMode { Accept, Reject }
		public AcceptMode Default { get; set; }
		public FilterExtension()
		{
			Default = AcceptMode.Accept;
		}
		private readonly Collection<FilterBase> _filters = new Collection<FilterBase>();
		public Collection<FilterBase> Filters { get { return _filters; } }
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return new FilterEventHandler((s, e) =>
				{
					e.Accepted = Default == AcceptMode.Accept;
					foreach (var filter in Filters)
					{
						var res = filter.Filter(e.Item);
						if (!res)
						{
							e.Accepted = false;
							return;
						}
					}
					e.Accepted = true;
				});
		}
	}
	public abstract class FilterBase : DependencyObject
	{
		public abstract bool Filter(object item);
	}
