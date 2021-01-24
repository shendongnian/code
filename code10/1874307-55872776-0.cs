    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    
    namespace ImageFileComparer
    {
        class ImageFileComparer
        {
    
            private string pathReferenceImg;
            private string pathTestImg;
            private FileInfo fReferenceFile;
            private FileInfo fTestFile;
            private Bitmap referenceImage;
            private Bitmap testImage;
            private int areaToCompareWidth;
            private int areaToCompareHeight;
            public int xMinAreaToCompare = 0;
            public int yMinAreaToCompare = 0;
            public int pixelDifferenceQuantity = 0;
            public List<Point> differentPixelsList = new List<Point>();
            private int tolerance = 15;
            public bool result;
    
            public ImageFileComparer(String pathReferenceImg, String pathTestImg)
            {
                this.pathReferenceImg = pathReferenceImg;
                this.pathTestImg = pathTestImg;
                fReferenceFile = new FileInfo(pathReferenceImg);
                fTestFile = new FileInfo(pathTestImg);
                referenceImage = new Bitmap(pathReferenceImg);
                testImage = new Bitmap(pathTestImg);
                areaToCompareWidth = referenceImage.Width;
                areaToCompareHeight = referenceImage.Height;
            }
    
            public void compareFiles()
            {
                Console.WriteLine("TEST: " + pathTestImg);
                Console.WriteLine("REF: " + pathReferenceImg);
    
                if (fReferenceFile.Exists &&
                    fTestFile.Exists &&
                    referenceImage.Width == testImage.Width &&
                    referenceImage.Height == testImage.Height)
                {
                    while (xMinAreaToCompare < areaToCompareWidth)
                    {
                        Color corRef = referenceImage.GetPixel(xMinAreaToCompare, yMinAreaToCompare);
                        Color corTeste = testImage.GetPixel(xMinAreaToCompare, yMinAreaToCompare);
                        //Magenta = 255R,255B,0G
                        if (corRef.ToArgb() != Color.Magenta.ToArgb())
                        {
                            if (corRef != corTeste)
                            {
                                pixelDifferenceQuantity++;
                                differentPixelsList.Add(new Point(xMinAreaToCompare, yMinAreaToCompare));
                            }
                        }
    
                        yMinAreaToCompare = yMinAreaToCompare + 1;
                        if (yMinAreaToCompare == areaToCompareHeight)
                        {
                            xMinAreaToCompare = xMinAreaToCompare + 1;
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
                        resultImage.Save(pathTestImg.Replace(".bmp", "_DIFERENCE.bmp"));
                    }
                    else
                    {
                        result = true;
                    }
                }
            }
    
            public bool getResult()
            {
                return result;
            }
    
            public List<Point> getDifferentPixelsList()
            {
                return differentPixelsList;
            }
        }
    }
