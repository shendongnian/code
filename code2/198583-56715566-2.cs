       public static byte[] imageConversion(string imageName){            
           
            //Initialize a file stream to read the image file
            FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
            //Initialize a byte array with size of stream
            byte[] imgByteArr = new byte[fs.Length];
            //Read data from the file stream and put into the byte array
            fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
            //Close a file stream
            fs.Close();
            
            return imageByteArr
        }
