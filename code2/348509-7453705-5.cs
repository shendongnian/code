    public void PrintChar(char charToPrint)
    {
        string filename = string.Format("{0}.txt", charToPrint);
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                foreach (char c in line.ToCharArray())
                {
                    Console.Write(c == '1' ? '*' : ' ');
                }
                Console.WriteLine();
            }
        }
    }
