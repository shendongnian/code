            double[] area = new double[contours.Size];
            for (int i = 0; i < contours.Size; i++)
            {
                area[i] = CvInvoke.ContourArea(contours[i]);
            }
            double[] mass_centerX = new double[contours.Size];
            double[] mass_centerY = new double[contours.Size];
            for (int i = 0; i < contours.Size; i++)
            {
                Moments mu = CvInvoke.Moments(contours[i], false);
                mass_centerX[i] = mu.M10 / mu.M00;
                mass_centerY[i] = mu.M01 / mu.M00;
                mass_centerX[i] = Math.Round(mass_centerX[i], 2);
                mass_centerY[i] = Math.Round(mass_centerY[i], 2);
            }
