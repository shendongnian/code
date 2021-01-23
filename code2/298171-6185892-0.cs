     public static List<T> ConvertData(List<T> oldDatas)
     {
         foreach (var itemList in oldDatas)
         {
             if (itemList is SomeType)
             {
                 var someTypeItem = (SomeType) itemList;
                 //code here
             }
             // or
             var someTypeItem = itemList as SomeType;
             if (someTypeItem != null)
             {
                 //code here
             }
         }
     }
