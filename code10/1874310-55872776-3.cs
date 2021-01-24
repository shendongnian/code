        public void compareFiles(string pathReferenceImg, string pathTestImg)
        {
            fReferenceFile = new FileInfo(pathReferenceImg);
            fTestFile = new FileInfo(pathTestImg);
            referenceImage = new Bitmap(pathReferenceImg);
            testImage = new Bitmap(pathTestImg);
            areaToCompareWidth = referenceImage.Width;
            areaToCompareHeight = referenceImage.Height;
                while (xMinAreaToCompare < areaToCompareWidth)
                {
                    Color colorRef = referenceImage.GetPixel(xMinAreaToCompare, yMinAreaToCompare);
                    Color colorTest = testImage.GetPixel(xMinAreaToCompare, yMinAreaToCompare);
                    //Magenta = 255R,255B,0G
                    if (colorRef.ToArgb() != Color.Magenta.ToArgb())
                    {
                        if (colorRef != colorTest)
                        {
                            pixelDifferenceQuantity++;
                            differentPixelsList.Add(new Point(xMinAreaToCompare, yMinAreaToCompare));
                        }
                    }
                    yMinAreaToCompare ++;
                    if (yMinAreaToCompare == areaToCompareHeight)
                    {
                        xMinAreaToCompare ++;
                        yMinAreaToCompare = 1;
                    }
                }
                if (pixelDifferenceQuantity >= tolerance)
                {
                    result = false;
                    Bitmap resultImage = new Bitmap(testImage);
                    foreach (Point pixel in differentPixelsList)
                    {
                        resultImage.SetPixel(pixel.X, pixel.Y, Color.Blue);
                    }
                    resultImage.Save(pathTestImg.Replace("TestFolder", "ResultFolder"));
                }
                else
                {
                    result = true;
                }
        }
