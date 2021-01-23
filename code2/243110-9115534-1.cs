		public struct ConfCode
		{
			public String Agency;
			public String CodeText;
			public String ToolTip;
			public Boolean IsActive;
			public Boolean IsDefault;
			public Boolean IsEmpty()
			{
				if (Agency == null & CodeText == null & ToolTip == null)
				{ return true; }
				else
				{ return false; }
			}
		}
