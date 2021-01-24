     try {
       // Possible FormatException throw (if user input is not a valid integer)
       int IloscPracownikow = Int32.Parse(Console.ReadLine());
       // and this will never throw FormatException
       object age = IloscPracownikow;
       Console.WriteLine("Podaj rok zalozenia firmy.");
       // Possible FormatException throw
       int Rok = Int32.Parse(Console.ReadLine());
       listaFirm.Add(new Firma(NazwaFirmy, IloscPracownikow, Rok));
     }
     catch (FormatException) {
       // either IloscPracownikow or Rok is invalid
       Console.WriteLine("Podaj liczbe, debilu");
     }
