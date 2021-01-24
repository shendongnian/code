     // Now we're working with item_1$Item_2$...$Item_N
     public static string GetCheckSum(string value) {
       // TODO: Validate string here
       return value
         .Split('$')
         .Select(item => Convert.ToInt64(item, 16)) // 16 is required in this format
         .Aggregate((s, item) => s ^ item)
         .ToString("X");
     }
     ...
     string test = "00$00$04$20$15$8e$00$08$b3$8d$00$08$b5$8d$00$08";
     // Let's have a look on the the array
     Console.WriteLine(string.Join(", ", test
                       .Split('$')
                       .Select(item => Convert.ToInt64(item, 16))));
     Console.Wrire(GetCheckSum(test));
