	var blah = _imageList.GroupBy(i => new { i.ImageID, i.ImageBytes })
						 .Select(x => new ImageView
						 {
						 	tag = x.Key.ImageID,
						    ImageData = x.Key.ImageBytes
						 }).ToList();
