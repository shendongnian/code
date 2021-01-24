    static void Main(string[] args)
        {
            int w = 0;
            int zig = 0;
            string[] IDs = Directory.GetFiles("C:/Users/ngallouj/Desktop/Script/test", "*.txt")
            .Select(x => Path.GetFileNameWithoutExtension(x).Split('_').Last())
            .Where(x => x.Length == 11).ToArray();
            for (int i = 0; i < IDs.Length; i++)
            {
                i++;
                Console.WriteLine("" + IDs[i - 1]);
                if (IDs[w] != IDs[i-1])
                {
                    w++;
                }else
                {
                    zig++;
                    if (zig == 4)
                    
{
                        Console.WriteLine("l'idée ci-dessous apparait : 4 fois");
                        Console.ReadLine();
                    }
                } 
                
            }
