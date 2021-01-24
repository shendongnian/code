    var userDictionary = new Dictionary<string,int>
    {
     	{ "BUL", 100 },
        { "GVL", 200 },
        { "UDF", 300 },
        { "RFT", 400 },
        { "WDR", 500 }
    };
    
    Console.WriteLine("\nUsername,Password \nBUL,100 \nGVL,200 \nUDF,300 \nRFT,400 \nWDR,500 ");
    var userName = ReadFromUserTillTrue("Enter UserName","Incorrect UserName",x=>userDictionary.Keys.Contains(x));
    var password = ReadFromUserTillTrue("Enter Password","Incorrect Password",x=>Int32.TryParse(x,out var value) && userDictionary[userName]== value);
