    static void Main(string[] args)
    {
        const int sLen = 30, Loops = 10000;
        DateTime sTime, eTime;
        int i;
        string sSource = new String('X', sLen);
        string sDest = "";
        // 
        // Time StringBuilder.
        // 
        for (int times = 0; times < 5; times++)
        {
            sTime = DateTime.Now;
            System.Text.StringBuilder sb = new System.Text.StringBuilder((int)(sLen * Loops * 1.1));
            Console.WriteLine("Result # " + (times + 1).ToString());
            for (i = 0; i < Loops; i++)
            {
                sb.Append(sSource);
            }
            sDest = sb.ToString();
            eTime = DateTime.Now;
            Console.WriteLine("String Builder took :" + (eTime - sTime).TotalSeconds + " seconds.");
            // 
            // Time string concatenation.
            // 
            sTime = DateTime.Now;
            for (i = 0; i < Loops; i++)
            {
                sDest += sSource;
                //Console.WriteLine(i);
            }
            eTime = DateTime.Now;
            Console.WriteLine("Concatenation took : " + (eTime - sTime).TotalSeconds + " seconds.");
            Console.WriteLine("\n");
        }
        // 
        // Make the console window stay open
        // so that you can see the results when running from the IDE.
        // 
    }
