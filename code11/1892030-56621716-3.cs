    class Program<TAny> where TAny : GET
    {
        static List<Tr> lst = new List<Tr>();
        public void Test(Tr merge)
        {
            lst.Add(merge);
            foreach (Tr cadt in lst)
            {
                Console.WriteLine($"Numarul este {cadt.Nume}");
            }
        }
    }
