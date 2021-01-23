    List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    int count = list.Count;
    int numGroups = list.Count / 3 + ((list.Count % 3 == 0) ? 0 : 1); // A partially-filled group is still a group!
    for (int i = 0; i < numGroups; i++)
    {
         int counterBase = i * 3;
         string s = list[counterBase].ToString(); // if this a partially filled group, the first element must be here...
         if (counterBase + 1 < count) // but the second...
              s += list[counterBase + 1].ToString(", 0");
         if (counterBase + 2 < count) // and third elements may not.
              s += list[counterBase + 2].ToString(", 0");
         Console.WriteLine(s);
    }
