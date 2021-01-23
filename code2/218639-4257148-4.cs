    class Box
    {
        public IEnumerable<Box> GetBoxes()
        {
            // avoid NullReferenceException
            var contents = this.Contents ?? Enumerable.Empty<Box>();
            // do the recursion
            return contents.SelectMany(b => b.GetBoxes()).Concat(contents);
        }
        public Box GetBox(int size)
        {
            return this.GetBoxes().FirstOrDefault(b => b.Size == size);
        }
    }
