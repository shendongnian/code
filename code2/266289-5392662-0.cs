    public class ImageData
    {
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("category")]
        public string Category { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
    }
    
    public class GalleryData
    {
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("uuid")]
        public string UUID { get; set; }
        [XmlElement("imagepath")]
        public string ImagePath { get; set; }
    }
    
    public class MyData
    {
        [XmlElement("galleryData")]
        public GalleryData GalleryData { get; set; }
    
        [XmlElement("imageData")]
        public ImageData[] ImageDatas { get; set; }
    }
    
