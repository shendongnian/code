        public static int FindSubArray(this Array x, Array y)
        {
            int offset = 0;
            var loYArray = new List<Object>();
            var ieYArray = y.GetEnumerator();
            while (ieYArray.MoveNext())
                loYArray.Add(ieYArray.Current);
            for (int i = 0; i < x.Length; ++i)
            {
                var loXSubArray = new List<Object>();
                var ieXArray = x.GetEnumerator();
                var iSkip = 0;
                while (ieXArray.MoveNext())
                {
                    iSkip++;
                    if (iSkip > i)
                        loXSubArray.Add(ieXArray.Current);
                    if (loXSubArray.Count >= y.Length)
                        break;
                }
                if (loYArray.SequenceEqual(loXSubArray))
                    return i;
            }
            return -1;
        }
