            bool finished = false;
            int firstSkip = 0;
            int lastSkip = 0;
            for (int i = 0; i <= data.Length - 1; i++)
            {
                if (finished == false)
                {
                    //T = transparent W = White;
                    //Find the First Batch of Colors TTTTWWWTTTT The top of the circle
                    if ((data[i] == Color.White) && (firstSkip == 0))
                    {
                        while (data[i + 1] == Color.White)
                        {
                            i++;
                        }
                        firstSkip = 1;
                        i++;
                    }
                    //Now Start Filling                       TTTTTTTTWWTTTTTTTT
                    //circle in Between                       TTTTTTW--->WTTTTTT
                    //transaparent blancks                    TTTTTWW--->WWTTTTT
                    //                                        TTTTTTW--->WTTTTTT
                    //                                        TTTTTTTTWWTTTTTTTT
                    if (firstSkip == 1)
                    {
                        if (data[i] == Color.White && data[i + 1] != Color.White)
                        {
                            i++;
                            while (data[i] != Color.White)
                            {
                                    //Loop to check if its the last row of pixels
                                    //We need to check this because of the 
                                    //int outerRadius = radius * 2 + -->'2'<--;
                                    for (int j = 1; j <= outerRadius; j++)
                                    {
                                        if (data[i + j] != Color.White)
                                        {
                                            lastSkip++;
                                        }
                                    }
                                    //If its the last line of pixels, end drawing
                                    if (lastSkip == outerRadius)
                                    {
                                        break;
                                        finished = true;
                                    }
                                    else
                                    {
                                        data[i] = Color.White;
                                        i++;
                                        lastSkip = 0;
                                    }
                                }
                            while (data[i] == Color.White)
                            {
                                i++;
                            }
                            i--;
                        }
                    }
                }
            }
            // Set the data when finished 
            //-- don't need to paste this part, already given up above
            texture.SetData(data);
            return texture;
 
