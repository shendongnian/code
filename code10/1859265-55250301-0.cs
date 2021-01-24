	public static void TakeElementScreenshot(IWebDriver driver, IWebElement element)
	{
		try
		{
			string screenshotName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "element_screenshot.jpg";
			Byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
			System.Drawing.Bitmap screenshot = new System.Drawing.Bitmap(new System.IO.MemoryStream(byteArray));
			System.Drawing.Rectangle eleImage = new System.Drawing.Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
			screenshot = screenshot.Clone(eleImage, screenshot.PixelFormat);
			screenshot.Save(String.Format(@"here goes the folder path" + screenshotName, System.Drawing.Imaging.ImageFormat.Jpeg));
		}
		catch (Exception e)
		{
			logger.Error(e.StackTrace + ':' + e.Message);
		}
	}
