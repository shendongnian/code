        public int[] shiftRight(int[] array, int shift)
        {
            var result = new List<int>();
            var toTake = array.Take(shift);
            var toSkip = array.Skip(shift);
            result.AddRange(toSkip);
            result.AddRange(toTake);
            return result.ToArray();
        }
