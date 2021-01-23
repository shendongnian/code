    double a, b;
    Console.WriteLine("istenen sayıyı sonuna .00 koyarak yaz");
    if (double.TryParse(Console.ReadLine(), out a)) {
      b = a * Math.PI;
      Console.WriteLine("Sonuç " + b); 
    } else {
      //user gave an illegal input. Handle it here.
    }
