    public void ImageTest()
        {
            // get image
            Image image = TakeScreen();
            // conver image to bytes
            byte[] img_byte_arr = ImageToBytes(image);
            // creat packet
            ImagePacket packet = new ImagePacket(img_byte_arr);
            // conver object to json there...
            // send json ...
            // receive json ...
            // convert json to object type of ImagePacket ...
            // get bytes from ImagePacket
            byte[] receive_bytes = packet.GetRawData();
            // conver bytes to Image
            Image receive_image = BytesToImage(receive_bytes);
        }
