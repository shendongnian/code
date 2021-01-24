    public class GeneratorLine : IComparable
    {
        public string TextString { get; set; }
        public int DatabaseId { get; set; }
        public int LineNumber { get; set; }
        public int Rank { get; set; }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            
            GeneratorLine otherLine = obj as GeneratorLine;
            if (otherLine != null)
            {
                int LineNumberComparison = this.LineNumber.CompareTo(otherLine.LineNumber);
                // if they have same LineNumber
                if (LineNumberComparison == 0)
                {
                    // compare them by DatabaseId
                    return this.DatabaseId.CompareTo(otherLine.DatabaseId);
                }
                // else compare them by LineNumber
                return LineNumberComparison;
            }
            else
               throw new ArgumentException("Object is not a GeneratorLine");
        }
    }
