    class Program<T> where T : GET
    {
        static List<T> lst = new List<T>();
        public void Test(T merge)
        {
            lst.Add(merge);
            foreach (T cadt in lst)
            {
                Console.WriteLine($"Numarul este {cadt.Nume}");
            }
        }
    }
