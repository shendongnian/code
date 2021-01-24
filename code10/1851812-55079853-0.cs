    MCvScalar m = new MCvScalar(0, 0, 255);
                listVecs[] = LineSegment2D();
                IOutputArray o;
                listVecs = CvInvoke.HoughLinesP(source, 1, Math.PI / 180, 50, 50, 10);
    
                for (int i = 0; i < listVecs.Length; i++)
                {
                    
    
                    CvInvoke.Line(cdst, listVecs[i].P1, listVecs[i].P2, m, 1, Emgu.CV.CvEnum.LineType.EightConnected, 8);
                }
