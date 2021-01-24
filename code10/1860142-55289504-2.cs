    private static double Negyzet(int alap, int kitevo)
        {
            Console.WriteLine("Kérem a hatvány alapját!");
            alap = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem a hatvány kitevojet!");
            kitevo = int.Parse(Console.ReadLine());
            return Math.Pow(alap, kitevo);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Kérem adja meg milyen műveletet szeretne elvégezni!\n\n+ összeadás\n- kivonás\n* szorzás\n/ osztás\n^hatványozás\n\nVálasztott művelet:");
            string muvelet = Console.ReadLine();
            switch (muvelet)
            {
                case "^": Console.WriteLine("A hatvány értéke:     {0}", Negyzet(0, 0));
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
