    private static List<int> GetSelectedItems(int sum)
            {
                var rest = new List<int>();
                var items = new List<int> { 64, 32, 16, 8, 4, 2, 1 };
                foreach (var item in items.OrderByDescending(a=>a))
                {
                    if(sum>=item)
                    {
                        rest.Add(item);
                        sum = sum - item;
                    }
                }
                return rest;
            }
