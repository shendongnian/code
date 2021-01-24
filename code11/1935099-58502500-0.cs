    public static void Main(string[] args)
    {
        string subtext = "polly";
        string text = "polly put the katle on,polly put the katle on,polly put the katle on,we all have tea";
        int index = 0;
        int startPosition = 0;
        bool found = false;
        while (index < text.Length - 1)
        {
            if (subtext[0] == text[index])
            {
                startPosition = index;
                index++;
                for (int j = 1; j <= subtext.Length - 1; j++)
                {
                    if (subtext[j] != text[index])
                    {
                        found = false;
                        break;
                    }
                    else
                    {
                        found = true;
                    }
                    index++;
                }
            }
            if (found)
            {
                Console.WriteLine("{0} found at index: {1}", subtext, startPosition);
                found = false;
            }
            index++;
        }
        Console.ReadLine();
    }
