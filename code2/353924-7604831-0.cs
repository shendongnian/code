    internal class DinoComparer : IComparer<Dinosaur>
    {
        public int Compare(Dinosaur dinosaur1, Dinosaur dinosaur2)
        {
            return Compare(dinosaur1.Id, dinosaur2.Id);
        }
        private int Compare(string x, string y)
        {
            return x.CompareTo(y);
        }
    }
    public class ComparerIssue
    {
        public void MainMethod()
        {
            List<Dinosaur> dinosaurs = new List<Dinosaur>();
            dinosaurs.Add(new Dinosaur() { Id = "D1.2", Name = "Pachycephalosaurus" });
            dinosaurs.Add(new Dinosaur() { Id = "D1.2", Name = "Amargasaurus" });
            dinosaurs.Add(new Dinosaur() { Id = "D1.2", Name = "Mamenchisaurus" });
            dinosaurs.Add(new Dinosaur() { Id = "D1.2", Name = "Deinonychus" });
            dinosaurs.Add(new Dinosaur() { Id = "D1.2", Name = "Coelophysis" });
            dinosaurs.Add(new Dinosaur() { Id = "D1.2", Name = "Oviraptor" });
            dinosaurs.Add(new Dinosaur() { Id = "D1.2", Name = "Tyrannosaur" });
            Display(dinosaurs);
            //Console.WriteLine("\nSort with unstable comparer:");
            //dinosaurs.Sort(new DinoComparer());
            Console.WriteLine("\nSort with stable comparer:");
            dinosaurs = (List<Dinosaur>)InsertionSort.Sort(dinosaurs, new DinoComparer().Compare);
            Display(dinosaurs);
        }
        private static void Display(IEnumerable<Dinosaur> list)
        {
            Console.WriteLine();
            foreach (Dinosaur dinosaur in list)
            {
                Console.WriteLine("Id: " + dinosaur.Id + " Name: " + dinosaur.Name);
            }
        }
    }
    public class Dinosaur
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class InsertionSort
    {
        public static IList<T> Sort<T>(IList<T> list, Comparison<T> comparison)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if (comparison == null)
                throw new ArgumentNullException("comparison");
            int count = list.Count;
            for (int j = 1; j < count; j++)
            {
                T key = list[j];
                int i = j - 1;
                for (; i >= 0 && comparison(list[i], key) > 0; i--)
                {
                    list[i + 1] = list[i];
                }
                list[i + 1] = key;
            }
            return list;
        }
    }
