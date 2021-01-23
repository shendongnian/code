            #region Find triangles and rectangles
            List<Triangle2DF> triangleList = new List<Triangle2DF>();
            List<MCvBox2D> boxList = new List<MCvBox2D>(); //a box is a rotated rectangle
            using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation
               for (Contour<Point> contours = cannyEdges.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,        Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage); contours != null; contours = contours.HNext)
               {
                  Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);
                  if (currentContour.Area > 250) //only consider contours with area greater than 250
                  {
                     if (currentContour.Total == 3) //The contour has 3 vertices, it is a triangle
                     {
                        Point[] pts = currentContour.ToArray();
                        triangleList.Add(new Triangle2DF(
                           pts[0],
                           pts[1],
                           pts[2]
                           ));
                     }
                     else if (currentContour.Total == 4) //The contour has 4 vertices.
                     {
                        #region determine if all the angles in the contour are within [80, 100] degree
                        bool isRectangle = true;
                        Point[] pts = currentContour.ToArray();
                        LineSegment2D[] edges = PointCollection.PolyLine(pts, true);
                        for (int i = 0; i < edges.Length; i++)
                        {
                           double angle = Math.Abs(
                              edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                           if (angle < 80 || angle > 100)
                           {
                              isRectangle = false;
                              break;
                           }
                        }
                        #endregion
                        if (isRectangle) boxList.Add(currentContour.GetMinAreaRect());
                     }
                  }
               }
            #endregion
