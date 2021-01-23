	using (MemoryStream ms = new MemoryStream())
	{
		System.Drawing.Image myImg = System.Drawing.Image.FromFile(imageDirectory + i.FileName);
		double xScale = 1;
		double yScale = 1;
		double maxWidthInches = 6.1; // Max width to fit on a page
		double maxHeightInches = 8.66; // Max height to fit on a page
		// Normalise the Horizontal and Vertical scale for different resolutions
		double hScale = ((double)96 / myImg.HorizontalResolution);
		double vScale = ((double)96 / myImg.VerticalResolution);
		// Scaling required to fit in x direction
		double imageWidthInches = myImg.Width / myImg.HorizontalResolution; // in inches using DPI
		if (imageWidthInches > maxWidthInches)
			xScale = maxWidthInches / imageWidthInches * hScale;
		// Scaling required to fit in y direction
		double imageHeightInches = myImg.Height / myImg.VerticalResolution;
		if (imageHeightInches > maxHeightInches)
			yScale = maxHeightInches / imageHeightInches * vScale;
		double finalScale = Math.Min(xScale, yScale); // Use the smallest of the two scales to ensure the picture will fit in both directions
		myImg.Save(ms, myImg.RawFormat); // Save your picture in a memory stream.
		ms.Seek(0, SeekOrigin.Begin);
		Novacode.Image img = document.AddImage(ms); // Create image.
		Paragraph p = document.InsertParagraph();
		Picture pic = img.CreatePicture(); // Create picture.
		//Apply final scale to height & width
		double width = Math.Round((double)myImg.Width * finalScale);
		double height = Math.Round((double)myImg.Height * finalScale);
		pic.Width = (int)(width);
		pic.Height = (int)(height);
		p.InsertPicture(pic); // Insert picture into paragraph.
	}
