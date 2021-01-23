     EuclideanColorFiltering filter = new EuclideanColorFiltering();            
     filter.CenterColor = new AForge.Imaging.RGB(Color.White); //Pure White
     filter.Radius = 0; //Increase this to allow off-whites
     filter.FillColor = new AForge.Imaging.RGB(Color.Red); //Replacement Colour
     filter.ApplyInPlace(image);
