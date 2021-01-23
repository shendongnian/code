    public static class Extensions
    {
        public static string Join(this object[] array, string[] delimiters)
        {
            var returnString = "";
            var s = new Queue<string>(delimiters);
            for (var i = 0; i < array.Count(); i++)
            {
                var delim = s.Dequeue();
                returnString += array[i] + delim;
                s.Enqueue(delim);
            }
            while (s.Count > 0) returnString = returnString.TrimEnd(s.Dequeue().ToCharArray());
            return returnString;
        }
    }
