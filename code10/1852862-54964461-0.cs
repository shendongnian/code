	public static class Ex
	{
		public static decimal? FindDecimalMaybe(this IWebDriver driver, string path)
		{
			try
			{
				if (decimal.TryParse(driver.FindElement(By.XPath(path)).Text, out decimal result))
				{
					return result;
				}
			}
			catch { } // I hate this, but there doesn't seem to be a choice
			return null;
		}
	}
