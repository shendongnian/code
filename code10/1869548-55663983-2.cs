    public static void Main(string[] args)
        {
            var parentNode = new Node();
            var childNodeOne = new Node();
            var childNodeTwo = new Node();
            var childNodeOneOne = new Node();
            childNodeOne.Children.Add(childNodeOneOne);
            parentNode.Children.Add(childNodeOne);
            parentNode.Children.Add(childNodeTwo);
            // Check is currently not modified
            Console.WriteLine($"Check: {parentNode.HasBeenModified}");
            // Mark node 2 has modified and check again
            childNodeTwo.HasBeenModified = true;
            Console.WriteLine($"Check: {parentNode.HasBeenModified}");
            // Unmark node 2 and make sure it's no longer modified
            childNodeTwo.HasBeenModified = false;
            Console.WriteLine($"Check: {parentNode.HasBeenModified}");
            // Mark the second level child node as modified and check parent is also showing as modified
            childNodeOneOne.HasBeenModified = true;
            Console.WriteLine($"Check: {parentNode.HasBeenModified}");
            Console.ReadKey();
        }
