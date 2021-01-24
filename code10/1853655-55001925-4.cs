     // Now we're working with item_1$Item_2$...$Item_N
     public static string GetCheckSum(string value) {
       // TODO: Validate string here
       return value
         .Split('$')
         .Select(item => Convert.ToInt64(item, 16)) // 16 is required in this format
         .Aggregate((s, item) => s ^ item)
         .ToString("X");
     }
