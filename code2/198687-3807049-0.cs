    void ComputeDenseOpticalFlow()
        {
            // Compute dense optical flow using Horn and Schunk algo
            velx = new Image<Gray, float>(faceGrayImage.Size);
            vely = new Image<Gray, float>(faceNextGrayImage.Size);
            
            OpticalFlow.HS(faceGrayImage, faceNextGrayImage, true, velx, vely, 0.1d, new MCvTermCriteria(100));            
            #region Dense Optical Flow Drawing
            Size winSize = new Size(10, 10);
            vectorFieldX = (int)Math.Round((double)faceGrayImage.Width / winSize.Width);
            vectorFieldY = (int)Math.Round((double)faceGrayImage.Height / winSize.Height);
            sumVectorFieldX = 0f;
            sumVectorFieldY = 0f;
            vectorField = new PointF[vectorFieldX][];
            for (int i = 0; i < vectorFieldX; i++)
            {
                vectorField[i] = new PointF[vectorFieldY];
                for (int j = 0; j < vectorFieldY; j++)
                {
                    Gray velx_gray = velx[j * winSize.Width, i * winSize.Width];
                    float velx_float = (float)velx_gray.Intensity;
                    Gray vely_gray = vely[j * winSize.Height, i * winSize.Height];
                    float vely_float = (float)vely_gray.Intensity;
                    sumVectorFieldX += velx_float;
                    sumVectorFieldY += vely_float;
                    vectorField[i][j] = new PointF(velx_float, vely_float);
                    Cross2DF cr = new Cross2DF(
                        new PointF((i*winSize.Width) +trackingArea.X,
                                   (j*winSize.Height)+trackingArea.Y),
                                   1, 1);
                    opticalFlowFrame.Draw(cr, new Bgr(Color.Red), 1);
                    LineSegment2D ci = new LineSegment2D(
                        new Point((i*winSize.Width)+trackingArea.X,
                                  (j * winSize.Height)+trackingArea.Y), 
                        new Point((int)((i * winSize.Width)  + trackingArea.X + velx_float),
                                  (int)((j * winSize.Height) + trackingArea.Y + vely_float)));
                    opticalFlowFrame.Draw(ci, new Bgr(Color.Yellow), 1);
                }
            }
            #endregion
        }
