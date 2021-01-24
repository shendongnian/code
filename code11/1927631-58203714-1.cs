	public sealed class InjectContentItemTransform : IItemTransform
	{
		private readonly string _content;
		public InjectContentItemTransform(string content)
		{
			_content = content;
		}
		public string Process(string includedVirtualPath, string input)
		{
			if (!_content.HasValue())
			{
				return input;
			}
			var builder = new StringBuilder();
			builder.AppendLine(_content);
			builder.Append(input);
			return builder.ToString();
		}
	}
