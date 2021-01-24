	olv.ShowGroups = false;
	//make 2 images
	var img1 = new Bitmap(10, 10);
	var g = Graphics.FromImage(img1);
	g.FillRectangle(new SolidBrush(Color.Pink),2,2,8,8 );
	var img2 = new Bitmap(10, 10);
	var g2 = Graphics.FromImage(img2);
	g2.FillRectangle(new SolidBrush(Color.Blue),2,2,8,8 );
	var col1 = new OLVColumn();
	col1.AspectName = "ToString";
	col1.ImageGetter += delegate(object rowObject)
	{
		if(rowObject == "1")
			return img1;
		if(rowObject == "2")
			return img2;
		if (rowObject == "3")
		{
			var comboImg = new Bitmap(img1.Width + img2.Width, img1.Height + img2.Height);
			using (var g3 = Graphics.FromImage(comboImg))
			{
				g3.DrawImage(img1,new Point(0,0));
				g3.DrawImage(img2,new Point(img1.Width,0));
			}
			return comboImg;
		}
			
		return null;
	};
	olv.Columns.Add(col1);
	olv.AddObject("1");
	olv.AddObject("2");
	olv.AddObject("3");
	}
