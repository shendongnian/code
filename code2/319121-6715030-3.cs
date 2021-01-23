    public static void Main()
    {
        const int COUNT = 10000;
        var r = new Random();
        int matchCount = 0;
        var stopwatch1 = new Stopwatch();
        var stopwatch2 = new Stopwatch();
        for (int j = 0; j < COUNT; j++)
        {
            var list = new List<int>(100) {1};
            for(int k=1; k<100; k++)
            {
                switch(r.Next(5))
                {
                    case 0:
                    case 1:
                    case 2:
                        list.Add(list[k - 1] + 1);
                        break;
                    case 3:
                        list.Add(list[k - 1] + r.Next(2));
                        break;
                    case 4:
                        list.Add(list[k - 1] - r.Next(5));
                        break;
                }
            }
            stopwatch1.Start();
            List<int> copy1 = Test1(new List<int>(list));
            stopwatch1.Stop();
            stopwatch2.Start();
            List<int> copy2 = Test2(new List<int>(list));
            stopwatch2.Stop();
            
            string list1 = String.Join(",", copy1);
            string list2 = String.Join(",", copy2);
            if (list1 == list2)
            {
                if (copy1.Count == list.Count)
                {
                    Console.WriteLine("No change:" + list1);
                }
                else
                {
                    matchCount++;
                }
            }
            else
            {
                Console.WriteLine("MISMATCH:");
                Console.WriteLine("   Orig  : " + String.Join(",", list));
                Console.WriteLine("   Test1 : " + list1);
                Console.WriteLine("   Test2 : " + list2);
            }
        }
        Console.WriteLine("Matches: " + matchCount);
        Console.WriteLine("Elapsed 1: {0:#,##0} ms", stopwatch1.ElapsedMilliseconds);
        Console.WriteLine("Elapsed 2: {0:#,##0} ms", stopwatch2.ElapsedMilliseconds);
    }
    public static List<int> Test1(List<int> arrayInput)
    {
        for (int i = 0; i < arrayInput.Count; i++)
        {
            if (i + 2 < arrayInput.Count)
            {
                if (arrayInput[i + 2] == arrayInput[i + 1] + 1
                && arrayInput[i + 2] == arrayInput[i] + 2)
                {
                    arrayInput.RemoveAt(i + 2);
                    arrayInput.RemoveAt(i);
                    List<int> temp = arrayInput;
                    Test1(temp);
                }
            }
            else
            {      // modified part: return the array
                return arrayInput;
            }
        }
        return arrayInput;
    }
    //method
    public static List<int> Test2(List<int> arrayInput)
    {
        for (int i = 0; i < arrayInput.Count - 2; i++)
        {
            if (arrayInput[i + 2] == arrayInput[i + 1] + 1
            && arrayInput[i + 2] == arrayInput[i] + 2)
            {
                arrayInput.RemoveAt(i + 2);
                arrayInput.RemoveAt(i);
                i = Math.Max(-1, i - 3); // -1 'cause i++ in loop will increment it
            }
        }
        return arrayInput;
    }
