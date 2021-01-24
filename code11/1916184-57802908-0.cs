                for (int k = 0; k < 3; k++)
                {
                    for (int j = 0; j < newBitmap.Height; j++)
                    {
                        for (int i = 0; i < newBitmap.Width; i++)
                        {
                            floatArray[k, j, i] = (float)Convert.ToDouble(image.Data[j, i, k]) - mean_vec[k];
                        }
                    }
                }
