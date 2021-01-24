    List<int> uzytkownik = new List<int>() { 99, 2, 3, 4, 5, 6 };
    
    List<int> uzytkownik1 = new List<int>();
    
    for (int i = 0; i < uzytkownik.Count; i++)
    {
    	uzytkownik1.Add(uzytkownik[i]);
    }
    
    for (int i = 0; i < uzytkownik1.Count; i++)
    {
    	Console.WriteLine(uzytkownik1[i]);
    }
    
    Console.ReadKey();
