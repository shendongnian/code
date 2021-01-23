     private BitmapImage LoadImage(string myImageFile)
            {
                BitmapImage myRetVal = null;
                if (myImageFile != null)
                {
                    BitmapImage image = new BitmapImage();
                    using (FileStream stream = File.OpenRead(myImageFile))
                    {
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = stream;
                        image.EndInit();
                    }
                    myRetVal = image;
                }
                return myRetVal;
            }
