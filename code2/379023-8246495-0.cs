        public static IEnumerable<Food> InterleaveFoods(IEnumerable<Food> source)
        {
            var groups = (from food in source
                          group food by food.idType into foodGroup
                          orderby foodGroup.Key
                          select foodGroup.ToArray())
                         .ToList();
                                                        
            int i = 0;
            while (groups.Any())
            {
                for (int group = 0; group < groups.Count; group++)
                {
                    if (i < groups[group].Length)
                        yield return groups[group][i];
                    else
                    {
                        // group is empty; remove it
                        groups.RemoveAt(group);
                        group--;
                    }
                }
                i++;
            }
        }
