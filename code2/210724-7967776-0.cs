    class Program
    {
        static void Main(string[] args)
        {
            var listofInts = new List<List<int>>(3);
            listofInts.Add(new List<int>{1, 2, 3});
            listofInts.Add(new List<int> { 4,5,6 });
            listofInts.Add(new List<int> { 7,8,9,10 });
            var temp = CrossJoinLists(listofInts);
            foreach (var l in temp)
            {
                foreach (var i in l)
                    Console.Write(i + ",");
                Console.WriteLine();
            }
        }
        private static IEnumerable<List<T>> CrossJoinLists<T>(IEnumerable<List<T>> listofObjects)
        {
            var result = from obj in listofObjects.First()
                         select new List<T> {obj};
            for (var i = 1; i < listofObjects.Count(); i++)
            {
                var iLocal = i;
                result = from obj  in result
                         from obj2 in listofObjects.ElementAt(iLocal)
                         select new List<T>(obj){ obj2 };
            }
            return result;
        }
    }
