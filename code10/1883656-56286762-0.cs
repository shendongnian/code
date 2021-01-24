            using (var file = File.CreateText())
            {
                int i = -1;// Loop counter
                int termReplacementIndex = 3;// Input or constant to find letter to replace
                foreach (var permutation in result)
                {
                    i++;
                    if (i == ((termReplacementIndex * 2) - 2))// Only stops on letters not commas
                    {
                        file.WriteLine(string.Join(",", " ,"));// Adding of blank " "
                    }
                    file.WriteLine(string.Join(",", permutation));// Adding of letter
                }
            }
