    public class JavaStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null) return 1;   // Not sure if this is what java does...
            if (y == null) return -1;  // modify to handle null conditions as appropriate
            // Find the common length of items to traverse
            var count = Math.Min(x.Length, y.Length);
            // For lexicographic comparison we can subtract the (integer) value
            // of the second character from the value of the first, which will 
            // produce a negative number if `x` is smaller or a positive number
            // if `x` is larger, which dictates our return value
            for (int i = 0; i < count; i++)
            {
                // Return the result of the first non-zero comparison
                int result = x[i] - y[i];
                // Convert the result to 1 or -1 by dividing it by it's absolute value
                if (result != 0) return result / Math.Abs(result);
            }
            // If the two strings have common beginnings, 
            // return the comparison of their lengths
            return x.Length.CompareTo(y.Length);
        }
    }
