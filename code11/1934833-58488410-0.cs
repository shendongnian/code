    string myLine = Console.ReadLine();
    int IloscPracownikow = 0;
    if(!Int32.TryParse(myLine, out IloscPracownikow))
    {
           Console.WriteLine("Podaj liczbe, debilu");
    }
