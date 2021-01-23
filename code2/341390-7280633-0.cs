    double a,b;
    Console.Writeline("istenen sayıyı sonuna .00 koyarak yaz");
    if (double.TryParse( Console.ReadLine(), out a )){
      b = a * Math.PI;
      Console.Writeline("Sonuç "+b); 
    }else{
      //user gave an illegal input. Handle it here.
    }
