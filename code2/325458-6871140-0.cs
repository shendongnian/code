    string numString = "012";
    var numChars = numString.ToCharArray();
    var result = new byte[numChars.Length];
    
    for (int i = 0; i < numChars.Length; i++)
    {
       result[i] = System.Convert.ToByte(numChars[i]);
    }
