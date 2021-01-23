        private static void TraverseInTwos()
        {
            var col = new Collection<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            int i = 0;
            while (col.Skip(i).Any())
            {
                var newCol = col.Skip(i).Take(2);
                Console.WriteLine(newCol.First() + " " + ((newCol.Count() > 1) ? newCol.Last().ToString() : string.Empty));
                i += 2;
            }
        }
