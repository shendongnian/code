            string[] arreglo = new string[6];
            arreglo[0] = "a";
            arreglo[1] = "b";
            arreglo[2] = "c";
            arreglo[3] = "d";
            arreglo[4] = "e";
            arreglo[5] = "f";
            var permutations = new List<string>();
            for (int i = 0; i < arreglo.Length; i++)
            {
                for (int j = 0; j < arreglo.Length; j++)
                {
                    for (int k = 0; k < arreglo.Length; k++)
                    {
                        for (int l = 0; l < arreglo.Length; l++)
                        {
                            for (int m = 0; m < arreglo.Length; m++)
                            {
                                for (int n = 0; n < arreglo.Length; n++)
                                {
                                    if (i ==j ||j == k||i == k||k == l||i == l||j == l||i == m||j == m||k == m||l == m||i == n||j == n||k == n||l == n||m == n)
                                        continue;
                                    var permutation = string.Format("{0}{1}{2}{3}{4}{5}", arreglo[i], arreglo[j], arreglo[k], arreglo[l], arreglo[m],arreglo[n]);
                                    permutations.Add(permutation);
                                }
                            }
                        }
                    }
                }
            }
            foreach(var element in permutations)
            {
                Console.WriteLine(element);
            }
            Console.ReadLine();
