                int[] possibleValues = new int[] { -1, 1 };
                var permutations = Permutations(possibleValues, 4);
                foreach(var permutation in permutations)
                {
                    foreach (int x in permutation)
                    {
                        Console.Write($"{x} \t");
                    }
                }
