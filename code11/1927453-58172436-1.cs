    static void Main(string[] args)
        {
            var entity1 = new Entity(new List<int> { 1, 2, 3 });
            var entity2 = new Entity(entity1);
            entity1.List[0] = 5;
            Console.WriteLine(entity2.List[0]);
        }
