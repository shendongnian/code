    using System.Linq;
    
    class Program
    {
        static void Main()
        {
            var list 
                = new[] { 1, 2, 3, 1, 2, 1, 5, 1, 2, 1, 1 };
    
            var filteredList 
                = list.TakeWhile(i => i != 5)
                        .Where(j => j == 1);
        }
    }
