		public struct ConfCode
		{
			public String Agency;
			public String CodeText;
			public String ToolTip;
			public Boolean IsActive;
			public Boolean IsDefault;
			public Boolean IsEmpty()
			{
				if (1 > Agency.Length + CodeText.Length + ToolTip.Length)
				{ return false; }
				else
				{ return true; }
			}
		}
