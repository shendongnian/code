    public static void figureModeOut(int[] source)
    {
        int[] numbers1 = { 1, 2, 3, 3, 2, 4 };
        var step1 = numbers1.GroupBy(x => x);
         foreach (var item in step1)
         {
             foreach (var element in item)
             {
                 Console.WriteLine("{0} - {1}", item.Key, element);
              }
         }
    }
