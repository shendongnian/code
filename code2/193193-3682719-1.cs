    RNB rnb = new RNB(100, 2);
    double result = rnb.ComputeBasicAmount();
    Console.WriteLine("RNB Basic Amt: " + result.ToString());
    HMS hms = new HMS() { Amount = 1000 };
    result = hms.ComputeBasicAmount();
    Console.WriteLine("HMS Basic Amt: " + result.ToString());
