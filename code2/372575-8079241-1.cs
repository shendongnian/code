	public static class ExtensionMethods
	{
		public static MessageType ConvertMessageType(this JabberMessageType jabberType)
		{
			switch(jabberType)
			{
				case JabberMessageType.normal:
					return MessageType.Normal;
				// Add rest of types here.
				default:
					return MessageType.Error;
			}
		}
	}
