    private DateTime[] GetDataForEntityInInterval(DateTime fromTime, DateTime toTime)
            {
                
            DateTime[] allValues = GetAllValuesFromDB();
            int indexFrom = Array.BinarySearch(allValues, fromTime);
             
             if(indexFrom < 0)
             {
                 int indexOfNearest = ~indexFrom;
                 if (indexOfNearest == allValues.Length)
                 {
                     //from time is larger than all elements
                     return null;
                 }
                 else if (indexOfNearest == 0)
                 {
                     // from time is less than first item
                     indexFrom = 0;
                 }
                 else
                 {
                     // from time is between (indexOfNearest - 1) and indexOfNearest
                     indexFrom = indexOfNearest;
                 }
             }
             int indexTo = Array.BinarySearch(allValues, toTime);
             if (indexTo < 0)
             {
                 int indexOfNearest = ~indexTo;
                 if (indexOfNearest == allValues.Length)
                 {
                     //to time is larger than all elements
                     indexTo = allValues.Length - 1;
                 }
                 else if (indexOfNearest == 0)
                 {
                     // to time is less than first item
                     return null;
                 }
                 else
                 {
                     // to time is between (indexOfNearest - 1) and indexOfNearest
                     indexTo = Math.Max(0, indexOfNearest - 1);
                 }
             }
            int length = indexTo - indexFrom;
            DateTime[] result = new DateTime[length];
            if (length > 0)
            {
                Array.Copy(allValues, indexFrom, result, 0, length);
            }
            return result;
        }
