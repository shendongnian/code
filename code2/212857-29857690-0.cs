        public void Save(string filename)
        {
            var ser = new XmlSerializer(this.GetType());
            using (var stream = new FileStream(filename, FileMode.Create))
                ser.Serialize(stream, this);
        }
