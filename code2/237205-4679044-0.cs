    [XmlRoot("EntityPhotos")]
        public class EntityPhotos
        {
            private List<String> _photos;
    
            public EntityPhotos()
            {
                _photos = new List<string>
                {
                    "One.jpg",
                    "Two.png",
                    "Three.gif"
                };
            }
    
            [XmlElement("Photos")]
            public String[] Photos
            {
                get
                {
                    return _photos.ToArray();
                }
    
                set  {;}
    
            }
    
            [XmlAttribute("Count")]
            public Int32 Count
            {
                get
                {
                    if (Photos != null)
                        return Photos.Length;
                    else
                        return 0;
                }
    
                set{;}
            }
        }
