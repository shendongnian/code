    public class GeneratorLine : IComparable
    {
        public string TextString { get; set; }
        public int DatabaseId { get; set; }
        public int LineNumber { get; set; }
        public int? Rank { get; set; } // If Rank can be null, its type should be int?
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            
            GeneratorLine otherLine = obj as GeneratorLine;
            if (otherLine != null)
            {
                // Set by default the comparison between ranks to 0 (meaning they are equals)
                int RankComparison = 0;
                // If both ranks are not null, let's compare them
			    if (Rank != null && otherLine.Rank != null)
				    RankComparison = (int)this.Rank?.CompareTo(otherLine.Rank);
                // If both ranks are equals or null
     			if (RankComparison == 0)
	    		{
                    // compare by LineNumber
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
                // If both ranks are not null and differents, return their comparison
                return RankComparison;
            }
            else
               throw new ArgumentException("Object is not a GeneratorLine");
        }
    }
