           using (Image image= dataObject.GetImage())
           {
                if (image != null)
                {
                    image.Save("test.bmp");
                }
            }
