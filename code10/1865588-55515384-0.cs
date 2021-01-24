    string myHexColor = "#ffeeff";
    int x = int.Parse(myHexColor.Substring(1), NumberStyles.HexNumber);
            
    Console.WriteLine("Color is:  " + x);              //   16772863 
    Console.WriteLine("Max short: " + short.MaxValue); //      32767
    Console.WriteLine("Max int:   " + int.MaxValue);   // 2147483647
