    int[] intarray = new int[] { 1, 1, 2, 3, 4, 4, 5, 7, 7, 7, 10 };
    int previousnumber = -1;
    List<int> doubleDigits = new List<int>();
    for (int i = 0; i < intarray.Length; i++)
    {
        if (previousnumber == -1) { previousnumber = intarray[i]; continue; }
        if (intarray[i] == previousnumber)
        {
            if (!doubleDigits.Contains(intarray[i]))
            {
                doubleDigits.Add(intarray[i]);
                //Console.WriteLine("Duplicate int found - " + intarray[i]);
                continue;
            }
        }
        else
        {
            previousnumber = intarray[i];
        }
    }
