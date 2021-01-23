        public static int AutoDropDownWidth(this ComboBox myCombo)
		{
			return AutoDropDownWidth<object>(myCombo, o => o.ToString());
		}
		public static int AutoDropDownWidth<T>(this ComboBox myCombo, Func<T, string> description)
		{
			int maxWidth = 1;
			int temp = 1;
			int vertScrollBarWidth = (myCombo.Items.Count > myCombo.MaxDropDownItems)
					? SystemInformation.VerticalScrollBarWidth : 0;
			foreach (T obj in myCombo.Items)
			{
				if (obj is T)
				{
					T t = (T)obj;
					temp = TextRenderer.MeasureText(description(t), myCombo.Font).Width;
					if (temp > maxWidth)
					{
						maxWidth = temp;
					}
				}
			}
			return maxWidth + vertScrollBarWidth;
		}
