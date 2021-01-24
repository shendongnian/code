    class Program
      {
        static void Main(string[] args)
        {
          // 1. Cow 2. Cat 3. Dog After Reverse: 4. Dog 5. Cat 6. Cow
          List<string> list = new List<string>() { "Cow", "Cat", "Dog" };
          ReverseList(list);
        }
    
        private static void ReverseList(List<string> list)
        {
          int i = 0;
          int j = list.Count - 1;
    
          for (i = 0; i < list.Count / 2; i++, j--)
          {
            string temp = list[i];
            list[i] = list[j];
            list[j] = temp;
          }
        }
      }
