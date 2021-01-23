    private void button7_Click(object sender, EventArgs e)
    {
         // Original
         string input = "ala bala portocala";
         Console.WriteLine(input);
    
         // XORed
         Console.WriteLine(doIt(input));
    
         // Double XORed to get original back
         Console.WriteLine(doIt(doIt(input)));
                            
    }
    
    public string doIt(string input)
    {
        var aChars = input.ToCharArray();
        var aCharsRes = new char[aChars.Length];
        for (int i=0; i<aChars.Length; i++)
        {
            aCharsRes[i] = (char)(aChars[i] ^ 1);
        }
    
        return new string(aCharsRes);
    }
