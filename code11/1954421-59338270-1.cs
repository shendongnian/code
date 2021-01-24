    public static void start()
    {
        for (int i = 0; i < codeNumber; i++)
        {
            //using (StreamWriter sw = File.AppendText("Codes.txt"))
            {
                Generate(16, maxDigit);
            }
        }
    }
