       static class Class1
       {
          static int[] _array;
          static Class1()
          {
             _array = new[] { 2 };
          }
    
          public static void FillArray()
          {
             List<int> temp = new List<int>();
             for (int i = 0; i < 100; i++)
             {
                temp.Add(i);
    
             }
             _array = temp.ToArray();
             PrintArray();
          }
    
          public static int[] GetArray()
          {
             PrintArray();
             return _array;
          }
    
          private static void PrintArray()
          {
             foreach (int i in _array)
             {
                System.Console.Write(String.Format("{0},", i));
             }
          }
    
       }
