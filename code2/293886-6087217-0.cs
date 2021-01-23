    var TarikhePayaneGozaresh = DateTime.Parse("9/9/2010 12:00:00 AM");
    var TarikheShorooeGharardad = DateTime.Parse("9/9/1991 12:00:00 AM");
    Swap<DateTime>(ref TarikhePayaneGozaresh, ref TarikheShorooeGharardad);
    Console.WriteLine(TarikhePayaneGozaresh); // 09/09/1991 00:00:00
    Console.WriteLine(TarikheShorooeGharardad); //09/09/2010 00:00:00
