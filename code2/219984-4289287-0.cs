    public partial class imageList : UserControl
        {
            public event OnChange;
            
            public imageList()
            {
                InitializeComponent();
            }
    
            public List<Image> Images { get; set; }
    
            public void AddImage(Image image)
            {
                Images.Add(image);
                this.OnChange();
            }
    
            public void RemoveImage(Image image)
            {
                Images.Remove(image);
                this.OnChange();
            }
    
            public void MoveImageLeft(int index)
            {
                Image tmpImage = Images[index];
                Images[index] = Images[index - 1];
                Images[index - 1] = tmpImage;
                this.OnChange();
            }
    
            public void MoveImageLeft(int index)
            {
                Image tmpImage = Images[index];
                Images[index] = Images[index + 1];
                Images[index + 1] = tmpImage;
                this.OnChange();
            }
        }
