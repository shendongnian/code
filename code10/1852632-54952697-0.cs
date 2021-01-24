     public static List<string> DivideIntoPartitions(string stringToDivide, int partitions)
            {
                var parts = new List<string>(partitions);
                var len = stringToDivide.Length;
    
                if (len < partitions)
                {
                    throw new ArgumentException("partitions should be less than length");
                }
    
                if (len % partitions == 0)
                {
                    var eachSubstrLength = len / partitions;
    
                    for (int i = 0; i < stringToDivide.Length; i += eachSubstrLength)
                    {
                        parts.Add(stringToDivide.Substring(i, eachSubstrLength));
                    }
                }
                else
                {
                    var nextDivisibleNumber = len + (partitions - (len % partitions));
                    var lengthOfLastSubstr = nextDivisibleNumber / partitions;
                    var lastItem = stringToDivide.Substring((len - lengthOfLastSubstr));
                    stringToDivide = stringToDivide.Remove((len - lengthOfLastSubstr));
    
                    var chunksize = stringToDivide.Length / (partitions - 1);
    
                    for (int i = 0; i < stringToDivide.Length; i += chunksize)
                    {
                        parts.Add(stringToDivide.Substring(i, chunksize));
                    }
                    parts.Add(lastItem);
    
                }
                return parts;
    
            }
     var result = DivideIntoPartitions("qrstuvwxyz", 3);
