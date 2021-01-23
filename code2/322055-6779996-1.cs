        public void Save(string filePath, byte [] content)
        {
            File.WriteAllBytes(filePath, content);
        }
        public byte [] Read(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }
