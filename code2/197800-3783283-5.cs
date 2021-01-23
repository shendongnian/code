     public IEnumerable<IEnumerable<T>> GetPages<T>(
             IList<T> source, int pageLength)
        {
            //validation here
            for (int startIndex = 0; 
                 startIndex < source.Count;
                 startIndex += pageLength)
            {
                yield return Page(source, startIndex, pageLength);
            }
        }
        public  IEnumerable<T> GetPage<T>(
             IList<T> source, int startIndex, int length)
        {
            //validation here
            for (int i = startIndex; 
                 i < startIndex + length && i < source.Count; 
                 i++)
            {
                yield return source[i];
            }
        }
