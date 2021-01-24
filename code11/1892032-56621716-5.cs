    class Program<TAny> where TAny : GET
    {
        static List<TAny> lst = new List<TAny>();
        public void Test(TAny merge)
        {
            lst.Add(merge);
            foreach (TAny cadt in lst)
            {
                Console.WriteLine($"Numarul este {cadt.Nume}");
            }
        }
    }
