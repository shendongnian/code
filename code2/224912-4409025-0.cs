        public void Save(int id, IEnumerable<ImageInfo> images)
        {
            foreach (var image in images)
            {
                SaveImage(image.Title, image.Name, image.Flag);
            }
        }
