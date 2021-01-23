     Private Image getEdge(Bitmap img)
                {
                Bitmap originalImage = img; // 
                // get grayscale image
                originalImage = Grayscale.CommonAlgorithms.RMY.Apply(img);
                // apply edge filter   
                IFilter ff = new SobelEdgeDetector();                     
                Bitmap b = ff.Apply(originalImage);
                originalImage.Dispose();
                return (Image)b;
                }
