         List<string> lines = new List<string>();
         using (var sr = new StreamReader("file.txt"))
         {
              while (sr.Peek() >= 0)
                  lines.Add(sr.ReadLine());
         }
     **Note:** `List<T>` has a constructor which accepts a capacity parameter. If you know the number of lines in advance, you can prevent multiple allocations by preallocating the array in advance:
         List<string> lines = new List<string>(NUMBER_OF_LINES);
