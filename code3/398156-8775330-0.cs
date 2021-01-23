     EuclideanColorFiltering filter = new EuclideanColorFiltering();            
     filter.CenterColor = Color.FromArgb(255,255,255); //Pure White
     filter.Radius = 0; //Increase this to allow off-whites
     filter.FillColor = Color.Red; //Replacement Colour
     filter.ApplyInPlace(image);
