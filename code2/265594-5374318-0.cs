    System.Drawing.Image newImage;
            using (MemoryStream ms = new MemoryStream(myByteArray, 0, myByteArray.Length))
            {
                ms.Write(myByteArray, 0, myByteArray.Length);
                newImage = Image.FromStream(ms, true);
            }
