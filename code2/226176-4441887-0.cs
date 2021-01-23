    var abc = Double.Parse(double.MaxValue.ToString("E20"));
    abc.Dump();
    
    double d;
    CultureInfo cultureInfo = new CultureInfo("en-US", true);
    if (Double.TryParse(double.MaxValue.ToString("E20"), NumberStyles.Any, cultureInfo.NumberFormat, out d)) Console.WriteLine("parsed");
    else Console.WriteLine("couldn't parse");
    
    if(d == double.MaxValue) Console.WriteLine("parsed value is equal to MaxValue");
    else Console.WriteLine("parsed value is NOT equal to MaxValue");
