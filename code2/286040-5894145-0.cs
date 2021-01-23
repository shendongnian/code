        public IEnumerator<IPin> GetEnumerator()
        {
            foreach (IPin pin in pins) yield return pin;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
