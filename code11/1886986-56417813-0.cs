    int[] tab1 = { 4, 6, 32, 16, 5, 22, -3, 61, 11, 99 };
    int[] tab2 = new int[tab1.Length];
    for (int i = 0; i < tab2.Length; i++)
    {
            if(tab1[i] > 0)
            {
                tab2[i] = tab1[i];
            }
     }
     for (int i = 0; i < tab2.Length; i++)
     {
           Console.Write(tab2[i] + ", ");
     }
     Console.ReadKey();
