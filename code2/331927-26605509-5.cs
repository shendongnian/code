        private string[] GetFullNamesOfImages()
        {
            string images = Path.Combine(_directoryName, "Images");
            if (!Directory.Exists(images))
                return new string[0];
            return Directory.GetFiles(images);
        }
