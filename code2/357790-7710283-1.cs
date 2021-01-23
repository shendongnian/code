    class MyDataObject : INotifyPropertyChanged
    {
        ...
        public Image MyProp
        {
            get
            {
                return CreateComparableImage(myImage, "myImage");
            }
        }
        private Image CreateComparableImage(Image image, string alias)
        {
            Image taggedImage = new Bitmap(image);
            taggedImage.Tag = alias;
            return taggedImage;
        }
    }
