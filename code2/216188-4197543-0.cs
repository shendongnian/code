            var bmp = new Bitmap(@"c:\temp\canon-ixus.jpg");
            if (bmp.PropertyIdList.Contains(37377)) {
                byte[] spencoded = bmp.GetPropertyItem(37377).Value;
                int numerator = BitConverter.ToInt32(spencoded, 0);
                int denominator = BitConverter.ToInt32(spencoded, 4);
                Console.WriteLine("Shutter speed = {0}/{1}", numerator, denominator);
            }
