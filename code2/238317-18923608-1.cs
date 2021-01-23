	public class ExpectedExceptionWithMessageAttribute : ExpectedExceptionBaseAttribute
	{
		public Type ExceptionType { get; set; }
		public Type ResourcesType { get; set; }
		public string ResourceName { get; set; }
		public string ExpectedMessage { get; set; }
		public bool Containing { get; set; }
		public bool IgnoreCase { get; set; }
		public ExpectedExceptionWithMessageAttribute(Type exceptionType)
			: this(exceptionType, null)
		{
		}
		public ExpectedExceptionWithMessageAttribute(Type exceptionType, string expectedMessage)
			: this(exceptionType, expectedMessage, false)
		{
		}
		public ExpectedExceptionWithMessageAttribute(Type exceptionType, string expectedMessage, bool containing)
		{
			this.ExceptionType = exceptionType;
			this.ExpectedMessage = expectedMessage;
			this.Containing = containing;
		}
		public ExpectedExceptionWithMessageAttribute(Type exceptionType, Type resourcesType, string resourceName)
			: this(exceptionType, resourcesType, resourceName, false)
		{
		}
		
		public ExpectedExceptionWithMessageAttribute(Type exceptionType, Type resourcesType, string resourceName, bool containing)
		{
			this.ExceptionType = exceptionType;
			this.ExpectedMessage = ExpectedMessage;
			this.ResourcesType = resourcesType;
			this.ResourceName = resourceName;
			this.Containing = containing;
		}
		protected override void Verify(Exception e)
		{
			if (e.GetType() != this.ExceptionType)
			{
				Assert.Fail(String.Format(
								"ExpectedExceptionWithMessageAttribute failed. Expected exception type: <{0}>. Actual exception type: <{1}>. Exception message: <{2}>",
								this.ExceptionType.FullName,
								e.GetType().FullName,
								e.Message
								)
							);
			}
			var actualMessage = e.Message.Trim();
			var expectedMessage = this.ExpectedMessage;
			if (expectedMessage == null)
			{
				if (this.ResourcesType != null && this.ResourceName != null)
				{
					PropertyInfo resourceProperty = this.ResourcesType.GetProperty(this.ResourceName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
					if (resourceProperty != null)
					{
						string resourceValue = null;
						try
						{
							resourceValue = resourceProperty.GetMethod.Invoke(null, null) as string;
						}
						finally
						{
							if (resourceValue != null)
							{
								expectedMessage = resourceValue;
							}
							else
							{
								Assert.Fail("ExpectedExceptionWithMessageAttribute failed. Could not get resource value. ResourceName: <{0}> ResourcesType<{1}>.",
								this.ResourceName,
								this.ResourcesType.FullName);
							}
						}
					}
					else
					{
						Assert.Fail("ExpectedExceptionWithMessageAttribute failed. Could not find static resource property on resources type. ResourceName: <{0}> ResourcesType<{1}>.",
							this.ResourceName,
							this.ResourcesType.FullName);
					}
				}
				else
				{
					Assert.Fail("ExpectedExceptionWithMessageAttribute failed. Both ResourcesType and ResourceName must be specified.");
				}
			}
			if (expectedMessage != null)
			{
				StringComparison stringComparison = this.IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
				if (this.Containing)
				{
					if (actualMessage == null || actualMessage.IndexOf(expectedMessage, stringComparison) == -1)
					{
						Assert.Fail(String.Format(
										"ExpectedExceptionWithMessageAttribute failed. Expected message: <{0}>. Actual message: <{1}>. Exception type: <{2}>",
										expectedMessage,
										e.Message,
										e.GetType().FullName
										)
									);
					}
				}
				else
				{
					if (!string.Equals(expectedMessage, actualMessage, stringComparison))
					{
						Assert.Fail(String.Format(
										"ExpectedExceptionWithMessageAttribute failed. Expected message to contain: <{0}>. Actual message: <{1}>. Exception type: <{2}>",
										expectedMessage,
										e.Message,
										e.GetType().FullName
										)
									);
					}
				}
			}
		}
	}
