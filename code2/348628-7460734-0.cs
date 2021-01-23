        [XmlIgnoreAttribute()]
        public Bitmap Picture = new Bitmap(1, 1);
        // Serializes the 'Picture' Bitmap to XML.
        [XmlElementAttribute("Picture")]
        public byte[] PictureByteArray
        {
            get
            {
                TypeConverter BitmapConverter = TypeDescriptor.GetConverter(Picture.GetType());
                return (byte[])BitmapConverter.ConvertTo(Picture, typeof(byte[]));
            }
            set
            {
                Picture = new Bitmap(new MemoryStream(value));
            }
        }
