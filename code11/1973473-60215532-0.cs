	public static void TestPlaceholderImage()
	{
		String path = "C:\\Aspose Data\\";
		Presentation pres = new Presentation(path + "TestPicture.pptx");
		foreach (ISlide slide in pres.Slides)
		{
			foreach (IShape shape in slide.Shapes)
			{
				if (shape.Placeholder != null)
				{
					if (shape.Placeholder.Type == PlaceholderType.Picture)
					{
						// Instantiate the ImageEx class
						System.Drawing.Image img = (System.Drawing.Image)new Bitmap(@"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg");
						IPPImage imgx = pres.Images.AddImage(img);
						shape.FillFormat.FillType = FillType.Picture;
						shape.FillFormat.PictureFillFormat.Picture.Image = imgx;
						if (shape is AutoShape)
						{
							ITextFrame text = ((IAutoShape)shape).TextFrame;
							text.Text = " ";
							text.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
						}
					}
				}
			}
		}
		pres.Save(path + "Addedpic.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
	}
