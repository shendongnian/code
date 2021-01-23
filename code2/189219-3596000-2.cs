    private static Table<Plant> plants;
    
    static void Main(string[] args)
    {
        using (var dataContext = new DataClasses1DataContext())
        {
            plants = dataContext.Plants;
            var treesNodes = GetTreesNodes(plants.Where(plant => plant.ID == 1));
            Console.WriteLine(string.Join(",",treesNodes.Select(plant => plant.ID)));
            // The previous line will print "1,2,4,3"
        }    
    }
    
    public static IEnumerable<Plant> GetTreesNodes(IEnumerable<Plant> roots)
    {
        if(!roots.Any())
        {
            return roots;
        }
    
        var children = roots.SelectMany(root => 
                                        plants.Where(plant => plant.Parent == root));
        return roots.Union(GetTreesNodes(children));
    }
