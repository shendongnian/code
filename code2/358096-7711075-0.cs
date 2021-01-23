        TextReader tr = new StreamReader("values.txt");
        string currentLine = null;
        do
        {
            Console.WriteLine("processing set of 5 lines");
            for (int i = 0; i < 5; i++)
            {
                currentLine = tr.ReadLine();
                if (currentLine == null)
                {
                    break;
                }
                Console.WriteLine("processing line {0} of 5", i);
                // your code goes here:
            }
        } while (currentLine != null);
