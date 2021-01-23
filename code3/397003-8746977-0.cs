        public Triangle(Point[] s)
        {
            // you could use more specific ArgumentNullException for first,
            // IllegalOperationException for second, etc, you get the point 
            // (no pun intended).
            if (s== null || s.Length != 3 || s.Any(x => x == null)) 
                throw new ArgumentException("s");
            ...
        }
