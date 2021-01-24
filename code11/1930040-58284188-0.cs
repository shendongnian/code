if (Geslacht == "man")
    {
        double Totaal;
        double LengteMan;
        double H = 100;
        double N = 0.9;
        Console.WriteLine("Wat is uw lichaamslengte in cm?");
        LengteMan = Convert.ToInt32(Console.ReadLine());
        Totaal = (LengteMan - H) * N;
        Console.WriteLine("Uw ideale gewicht is " + Totaal + " Kilo");
        Console.ReadKey();
    }
    else if (Geslacht == "vrouw")
    {
        Console.WriteLine("TestVrouw");
    }
    else
    {
        Console.WriteLine("error");
    }
