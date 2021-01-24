    int[] tab1 = { 4, 6, 32, 16, 5, 22, -3, 61, 11, 99 };
    List<int> tab2 = new List<int>();// because you dont know how many items positive
    for (int i = 0; i < tab1.Length; i++)
    {
        if (tab1[i] > 0)
        {
          tab2.Add(tab1[i]);
         }
      }
     for (int i = 0; i < tab2.Count; i++)
     {
       Console.Write(tab2[i] + ", ");
     }
     Console.ReadKey();
