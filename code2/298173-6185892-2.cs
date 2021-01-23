     public static List<T> ConvertData(List<T> oldDatas)
     {
         foreach (var itemList in oldDatas)
         {
             if (itemList is LinqType)
             {
                 var linqTypeItem = (LinqType) itemList;
                 Console.WriteLine(linqTypeItem.PROPERTY_YOU_NEED);
             }
             // or
             var linqTypeItem = itemList as LinqType;
             if (linqTypeItem != null)
             {
                 Console.WriteLine(linqTypeItem.PROPERTY_YOU_NEED);
             }
         }
     }
