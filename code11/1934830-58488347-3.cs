      if (int.TryParse(Console.ReadLine(), out int IloscPracownikow)) {
        // User input - Console.ReadLine() - is a valid integer (IloscPracownikow)
        object age = IloscPracownikow;
        ...
      }
      else {
        // User input - Console.ReadLine() - is NOT a valid integer
        Console.WriteLine("Podaj liczbe, debilu");
        ...
      }  
